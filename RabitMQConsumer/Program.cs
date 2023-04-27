using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Text;
using OfficeOpenXml;
using System.Collections.Generic;
using Newtonsoft.Json;
using Common.Model;
using ContactReportAPI.Helper;

namespace RabitMQConsumer
{
    internal class Program
    {
        static void Main()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            string message = "";
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("contact", exclusive: false);
            //Set Event object which listen message from chanel which is sent by producer
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Product message received: ${0}", message);
                CreateExcel(message);

            };
            //read the message
            channel.BasicConsume(queue: "contact", autoAck: true, consumer: consumer);
            Console.ReadKey();
        }

        private static void CreateExcel(string message)
        {
            var reportModel = JsonConvert.DeserializeObject<ResultModel<ReportModel>>(message);
            List<Guid> reportIds = new List<Guid>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
            worksheet.Cells[1, 1].Value = "Konum Bilgisi";
            worksheet.Cells[1, 2].Value = "Konumdaki Kayıtlı Kişi Sayısı";
            worksheet.Cells[1, 3].Value = "Konumdaki Kayıtlı Telefon Sayısı";
            int k = 2;
            if (reportModel != null)
            {
                for (int i = 0; i < reportModel.DataList.Count; i++)
                {
                    worksheet.Cells[k, 1].Value = reportModel.DataList[i].Longitude + "," + reportModel.DataList[i].Latitude;
                    worksheet.Cells[k, 2].Value = reportModel.DataList[i].KayitliKisi;
                    worksheet.Cells[k, 3].Value = reportModel.DataList[i].KayitliTelefonNo;
                    k++;
                    reportIds.Add(reportModel.DataList[i].Id);
                    string fileName = reportModel.DataList[i].Path;
                    System.IO.FileInfo file = new System.IO.FileInfo(fileName);
                    excelPackage.SaveAs(file);
                }
            }
            ReportComplete(reportIds);
        }
        private static void ReportComplete(List<Guid> reportIds)
        {
            var json = JsonConvert.SerializeObject(reportIds);
            RestHelper.PostRequestAsync("http://localhost:5001/api/Report/Update", json);
        }
    }
}
