﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Contracts.Commands;

namespace Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CommandController : ApiController
    {
        [Route("deposant")]
        [HttpPost]
        public async Task<HttpResponseMessage> Deposant()
        {
            var endpoint = await ServiceBusConfig.BusControl.GetSendEndpoint(new Uri("rabbitmq://localhost/deposant"));

            await endpoint.Send<CreateDeposant>(new {});

            return Request.CreateResponse(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        [Route("gebruiker")]
        [HttpPost]
        public async Task<HttpResponseMessage> Gebruiker()
        {
            var endpoint = await ServiceBusConfig.BusControl.GetSendEndpoint(new Uri("rabbitmq://localhost/gebruiker"));

            await endpoint.Send<CreateGebruiker>(new
            {
                Id = Guid.NewGuid()
            });

            return Request.CreateResponse(new HttpResponseMessage(HttpStatusCode.NoContent));
        }
    }
}
