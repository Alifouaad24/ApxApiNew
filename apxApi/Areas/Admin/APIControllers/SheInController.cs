using apxApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System.Net;

namespace apxApi.Areas.Admin.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheInController : ControllerBase
    {
        ApiResponse _response { get; set; }
        public SheInController(ApiResponse response)
        {
            _response = response;
        }


        [HttpPost("GetPhoto")]
        public async Task<IActionResult> GetPhoto([FromBody] SheIn newModel)
        {

            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    driver.Navigate().GoToUrl(newModel.URL);
                    await Task.Delay(10000);

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElement(By.XPath("//img")));
                    var imageElement = driver.FindElements(By.XPath("//img[contains(@class, 'crop-image-container__img')]")).FirstOrDefault();
                    if (imageElement != null)
                    {
                        var imageUrl = imageElement.GetAttribute("src");

                        var skuElement = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
                        if (skuElement != null)
                        {
                            var sku = skuElement.Text.Replace("SKU: ", "");

                            _response.Result = new { ImageURL = imageUrl, Title = sku };



                            _response.StatusCode = HttpStatusCode.OK;
                            return Ok(_response);

                        }
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.Result = "Image not found.";
                        return Ok(_response);
                    }
                }


                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string> { ex.Message };
                }
                return Ok(_response);
            }
        }


        [HttpPost("GetSKU")]
        public async Task<IActionResult> GetSKU([FromBody] SheIn newModel)
        {

            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    driver.Navigate().GoToUrl(newModel.URL);
                    await Task.Delay(4000);

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    wait.Until(driver => driver.FindElement(By.XPath("//img")));
                    var skuElement = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
                    if (skuElement != null)
                    {
                        var sku = skuElement.Text.Replace("SKU: ", "");

                        _response.Result = new { Title = sku };
                        _response.StatusCode = HttpStatusCode.OK;
                        return Ok(_response);
                    }
                    else
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.Result = "Image not found.";
                        return Ok(_response);
                    }
                }


                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string> { ex.Message };
                }
                return Ok(_response);
            }
        }


        [HttpPost("GetFinallUrl")]
        public async Task<IActionResult> GetFinallUrl([FromBody] SheIn newModel)
        {

            var options = new ChromeOptions();
            options.AddArgument("start-maximized");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    driver.Navigate().GoToUrl(newModel.URL);
                    await Task.Delay(5000);

                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                    string finallUrl = driver.Url.ToString();   

                    _response.Result = new { FinallURL = finallUrl };
                    _response.StatusCode = HttpStatusCode.OK;
                    return Ok(_response);
                }


                catch (Exception ex)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessage = new List<string> { ex.Message };
                }
                return Ok(_response);
            }
        }

    }
}
