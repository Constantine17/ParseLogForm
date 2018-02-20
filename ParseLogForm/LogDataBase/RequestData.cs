using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLogDataBase
{
    /// <summary>
    /// Обектная модель лога
    /// </summary>
    public struct RequestData
    {
        /// <summary>
        /// Дата и время запроса
        /// </summary>
        public DateTime RequestDate;
        /// <summary>
        /// Время по UTC
        /// </summary>
        public string UtcCode;
        /// <summary>
        /// IP или хост запроса
        /// </summary>
        public string IPorHost;
        /// <summary>
        /// IP-адрес или имя хоста, который выполнял запрос
        /// </summary>
        public string TypeRequest;
        /// <summary>
        /// Роут, к которому был реализован запрос
        /// </summary>
        public string Route;
        /// <summary>
        /// Дополнительные параметры, с которыми происходил запрос (URL Query Parameters)
        /// </summary>
        public string Parameters;
        /// <summary>
        /// Код результата запроса
        /// </summary>
        public int Code;
        /// <summary>
        /// Размер в байтах, переданный клиенту.
        /// </summary>
        public Int64 SizeByte;
        /// <summary>
        /// Геолокация хоста
        /// </summary>
        public string Geolocation;
    }

    /// <summary>
    /// Запрос на получение колекции хостов или роутов
    /// </summary>
    public struct Query
    {
        /// <summary>
        /// количество хостов/роутов
        /// </summary>
        public int n;
        /// <summary>
        /// дата начала промежутка времени
        /// </summary>
        public DateTime start;
        /// <summary>
        /// дата окончания промежутка времени
        /// </summary>
        public DateTime end;
    }
}
