using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fanoutput;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OO4.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FanOutputController : ControllerBase
    {
        public static int nextId = 4;
        public static List<FanOutput> ListOfFanOutputs = new List<FanOutput>() { new FanOutput() { Id = 1 }, new FanOutput() { Id = 2 }, new FanOutput() { Id = 3 } };

        // GET: api/<FanOutputController>
        [HttpGet]
        public List<FanOutput> Get()
        {
            return ListOfFanOutputs;
        }

        // GET api/<FanOutputController>/5
        [HttpGet("{id}")]
        public FanOutput Get(int id)
        {
            return ListOfFanOutputs.Find(fan => fan.Id == id);
        }

        // POST api/<FanOutputController>
        [HttpPost]
        public void Post([FromBody] FanOutput value)
        {
            try
            {
                value.Id = nextId;
                ListOfFanOutputs.Add(value);
                nextId++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

        }

        // PUT api/<FanOutputController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FanOutput value)
        {
            FanOutput fan = Get(id);

            if (fan != null)
            {
                fan.Fugt = value.Fugt;
                fan.Name = value.Name;
                fan.Temp = value.Temp;
            }
        }

        // DELETE api/<FanOutputController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            FanOutput fan = Get(id);
            ListOfFanOutputs.Remove(fan);
        }
    }
}
