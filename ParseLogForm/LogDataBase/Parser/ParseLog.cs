using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using EntityLogDataBase;
using System.Threading;

namespace EntityLogDataBase.Parser
{
    class ParseLog
    {
        string directoryFile = @"D:\programs\GIT_ASP.NET\ParseLog\Console\access_log";

        Regex ipOrHost = new Regex(@"\b(.*) - -");
        Regex dateOrUtc = new Regex(@"\[(.*) (.*)\] \""");
        Regex requst = new Regex(@"\""(.*) (.*) (.*)\""");
        Regex route = new Regex(@"(.*)\?(.*)");
        Regex codeRequstaAndByte = new Regex(@"\"" (.*) (.*)$");
        const string formatDate = "dd/MMM/yyyy:HH:mm:ss";
        Geolocation Geolocation = new Geolocation();
        LogDataBase ConnectionToDataBase;

        /// <summary>
        /// Количество записаных логов
        /// </summary>
        public int QuantityLogs { get; private set; } = 0;
        /// <summary>
        /// Количество строк в лог файле
        /// </summary>
        public int QuantityLines { get; private set; } = 1;

        /// <summary>
        /// инстализирует новый объект класса 
        /// </summary>
        /// <param name="дериктория файла"></param>
        /// <param name="строка подключения к файлу"></param>
        public ParseLog(string directory, string stringConnection)
        {
            this.directoryFile = directory;
            this.ConnectionToDataBase = new LogDataBase(stringConnection);
        }
        /// <summary>
        /// // прогресс добавление логов в базу (от 0 до 1)
        /// </summary>
        /// <returns></returns>
        public float GetProgess()
        {
            float fl = QuantityLines;
            return QuantityLogs / fl;
        }

        /// <summary>
        /// чтение лог файла и добовление в базу асинхронно
        /// </summary>
        public void ReadLogFile()
        {
            int i = 0;
            Action<string> ParseLineAction = ParseLine;
            var readFile = File.OpenText(directoryFile);

            while (true)
            {
                string line = readFile.ReadLine();
                if (line != null) Task.Run(() => ParseLineAction(line)); // запись лога асинхронно
                else break;
                if (i >= 50) break;// заглушка
                i++; 
            }
            readFile.Close();
            readFile.Dispose();
            QuantityLines = i;
        }

        // парсинг строки лога и добавление лога в базу
        private void ParseLine(string line)
        {
                //199.72.81.55 - - [01/Jul/1995:00:00:01 -0400] "GET /history/apollo?parametr1=1 HTTP/1.0" 200 6245
                RequestData requestData = new RequestData();

                // регулярные вырожения, иницилизируються в конструкторе
                //Regex ipOrHost = new Regex(@"\b(.*) - -");
                //Regex dateOrUtc = new Regex(@"\[(.*) (.*)\] \""");
                //Regex requst = new Regex(@"\""(.*) (.*) (.*)\""");
                //Regex route = new Regex(@"(.*)\?(.*)");
                //Regex codeRequstaAndByte = new Regex(@"\"" (.*) (.*)$");
                //const string formatDate = "dd/MMM/yyyy:HH:mm:ss";

                requestData.IPorHost = ipOrHost.Match(line).Groups[1].Value;
                string date = dateOrUtc.Match(line).Groups[1].Value;

                requestData.RequestDate = DateTime.ParseExact(date, formatDate, System.Globalization.CultureInfo.InvariantCulture);
                requestData.UtcCode = dateOrUtc.Match(line).Groups[2].Value;
                requestData.TypeRequest = requst.Match(line).Groups[1].Value;

                string requestStr = requst.Match(line).Groups[2].Value; // получение строки типа, рооута и дополнительных параметров запроса
                requestData.Route = route.Match(requestStr).Groups[1].Value;
                if (requestData.Route == "") requestData.Route = requestStr;
                requestData.Parameters = route.Match(requestStr).Groups[2].Value;

                requestData.Code = Convert.ToInt32(codeRequstaAndByte.Match(line).Groups[1].Value);
                try { requestData.SizeByte = Convert.ToInt64(codeRequstaAndByte.Match(line).Groups[2].Value); } catch { }//если размер не указан в логе
                requestData.Geolocation = Geolocation.GetLocation(requestData.IPorHost);// геолокация

                ConnectionToDataBase.AddRequestData(requestData);
                QuantityLogs++;
        }
    }
}
