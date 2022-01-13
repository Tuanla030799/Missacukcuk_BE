using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class MISAEntityController<MISAEntity> : ControllerBase
    {
        //GET: api/<EmployeeController>
        IBaseBL<MISAEntity> _baseBL;

        public MISAEntityController(IBaseBL<MISAEntity> baseBL)
        {
            _baseBL = baseBL;
        }
        [HttpGet]
        public IActionResult Get()
        {
            
            var entitys = _baseBL.GetAll();
            if (entitys.Count() == 0)
            {
                return NoContent();

            }
            else
            {
                return Ok(entitys);
            }

        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
           
            var entity = _baseBL.GetById(id);
            // 4. Trả về cho Client:
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet("Fillter/divPage")]
        public IActionResult GetFind(String FindAll, int pageSize, int pageIndex)
        {

            var entity = _baseBL.GetFindBy(FindAll, pageSize, pageIndex);
            // 4. Trả về cho Client:
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpGet("Fillter/TotalPage")]
        public IActionResult GetTotalFillter(String Find)
        {

            var entity = _baseBL.GetTotalFillter(Find);
            // 4. Trả về cho Client:
            if (entity != null)
            {
                return Ok(entity);
            }
            else
            {
                return NoContent();
            }
        }

        //[HttpGet("name")]
        //public IActionResult GetByName(string name)
        //{

        //    var entity = _baseBL.GetByCode(name);
        //    // 4. Trả về cho Client:
        //    if (entity != null)
        //    {
        //        return Ok(entity);
        //    }
        //    else
        //    {
        //        return NoContent();
        //    }
        //}

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity entity)
        {
            try
            {

               
                var rowAffects = _baseBL.Insert(entity);
                // 4. Trả về cho Client:
                if (rowAffects > 0)
                {
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<MISAEntity> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "EmployeeCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {

                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "EmployeeCode"
                };
                return StatusCode(500, mes);
            }

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MISAEntity entity)
        {
           
            try{
                var res = _baseBL.Update(entity, id);
                if (res > 0)
                {
                    return Ok(res);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<MISAEntity> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "EmployeeCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {

                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "EmployeeCode"
                };
                return StatusCode(500, mes);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
           
            var res = _baseBL.Delete(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
