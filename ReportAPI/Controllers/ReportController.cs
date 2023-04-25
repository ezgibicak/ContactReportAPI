using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using ReportAPI.Interface;
using ReportAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReportAPI.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportBusiness reportBusiness;
        private SonucModel<ReportModel> sonucModel;
        public ReportController(IReportBusiness _reportBusiness)
        {
            reportBusiness = _reportBusiness;
            sonucModel = new SonucModel<ReportModel>();
        }
        [HttpPost]
        public async Task<ActionResult<SonucModel<ReportModel>>> Post()
        {
            using var streamReader = new StreamReader(Request.Body, Encoding.UTF8);
            var requestBody = await streamReader.ReadToEndAsync();

            sonucModel.Data = JsonConvert.DeserializeObject<List<ReportModel>>(requestBody);
            await reportBusiness.Post(sonucModel.Data);
            sonucModel.Mesaj = "Başarılı";

            return sonucModel;
        }

        [HttpGet]
        public async Task<ActionResult<SonucModel<ReportModel>>> Get()
        {
            sonucModel = await reportBusiness.Get();
            return sonucModel;
            //Rabitmq
            //var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest", VirtualHost = "/" };
            //using var connection = factory.CreateConnection();
            //using var channel = connection.CreateModel();

            //channel.QueueDeclare(queue: "hello",
            //                     durable: false,
            //                     exclusive: false,
            //                     autoDelete: false,
            //                     arguments: null);

            //Console.WriteLine(" [*] Waiting for messages.");

            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{
            //    var body = ea.Body.ToArray();
            //    var message = Encoding.UTF8.GetString(body);
            //    Console.WriteLine($" [x] Received {message}");
            //};
            //channel.BasicConsume(queue: "hello",
            //                     autoAck: true,
            //                     consumer: consumer);

            //Console.WriteLine(" Press [enter] to exit.");
            //Console.ReadLine();

        }
    }
}
