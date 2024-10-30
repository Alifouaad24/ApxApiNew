using AinAlfahd.Data;
using apxApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Net;
using AinAlfahd.Models;

namespace apxApi.Areas.Admin.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        MasterDBContext dBContext;
        public LogController(MasterDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        [HttpPost("AddLog")]
        public async Task<IActionResult> AddLog([FromBody] SheIn newModel)
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
                    wait.Until(driver => driver.FindElement(By.XPath("//img | //div")));
                    var skuElement = driver.FindElements(By.XPath("//div[contains(@class, 'product-intro__head-sku')]//span[contains(@class, 'product-intro__head-sku-text')]")).FirstOrDefault();
                    if (skuElement != null)
                    {
                        var sku = skuElement.Text.Replace("SKU: ", "");

                        var newLog = new TblLog
                        {
                            InputParamiter = newModel.URL,
                            OutputParamiter = finallUrl,
                            Result = sku,
                            InsertDt = DateTime.Now,
                        };

                        await dBContext.TblLogs.AddAsync(newLog);
                        await dBContext.SaveChangesAsync();
                        return Ok(newLog);
                    }
                    else
                    {
                        var newLog = new TblLog
                        {
                            InputParamiter = newModel.URL,
                            OutputParamiter = finallUrl,
                            Result = "Image not found",
                            InsertDt = DateTime.Now,
                        };

                        await dBContext.TblLogs.AddAsync(newLog);
                        await dBContext.SaveChangesAsync();
                        return Ok(newLog);
                    }
                }


                catch (Exception ex)
                {
                    var newLog = new TblLog
                    {
                        InputParamiter = newModel.URL,
                        OutputParamiter = "Error",
                        Result = "Error during Scraping the website",
                        InsertDt = DateTime.Now,
                    };

                    await dBContext.TblLogs.AddAsync(newLog);
                    await dBContext.SaveChangesAsync();
                    return Ok(newLog);
                }
            }
        }
    }
}
