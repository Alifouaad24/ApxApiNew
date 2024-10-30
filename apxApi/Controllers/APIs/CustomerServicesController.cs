﻿//using AinAlfahd.BL;
//using AinAlfahd.Data;
//using AinAlfahd.Models;
//using AinAlfahd.ModelsDTO;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace AinAlfahd.Areas.Admin.APIs
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerServicesController : ControllerBase
//    {
//        ICustomerServices customerServices;
//        MasterDBContext db;
//        public CustomerServicesController(ICustomerServices customerServices, MasterDBContext db)
//        {
//            this.customerServices = customerServices;
//            this.db = db;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var customersService = await customerServices.GetAll();
//            return Ok(customersService);
//        }

//        [HttpGet("GetBySearch/{cusId}/{serId}")]
//        public async Task<IActionResult> GetBySearch(int cusId, int serId)
//        {
//            var customersService = await customerServices.GetByPier(cusId, serId);
//            return Ok(customersService);
//        }


//        [HttpPost]
//        public async Task<IActionResult> AddData([FromBody] CustomerServiceDto model)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);
//            var customerSer = new CustomerService
//            {
//                CustomerId = model.CustomerId,
//                ServiceId = model.ServiceId,
//            };
//            await customerServices.AddData(customerSer);

//            return Ok(customerSer);
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateData(int cusId, int serId,  [FromBody] CustomerServiceDto model)
//        {
//            var existingCustomerSer = await customerServices.GetByPier(cusId, serId);
//            if (existingCustomerSer == null)
//                return NotFound();

//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            existingCustomerSer.CustomerId = model.CustomerId;
//            existingCustomerSer.ServiceId = model.ServiceId;

//            await customerServices.UpdateData(existingCustomerSer);

//            return Ok(existingCustomerSer);
//        }


//        [HttpDelete]
//        public async Task<IActionResult> DeleteData(int cusId, int serId)
//        {
//            var cus = await customerServices.GetByPier(cusId, serId);
//            if (cus == null)
//                return NotFound();

//            var result = await customerServices.DeleteData(cusId, serId);
//            if (!result)
//                return BadRequest();

//            return Ok(result);
//        }
//    }
//}
