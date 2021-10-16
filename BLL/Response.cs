using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace BLL
{
    public class Response<T>
    {
        public string Message { get; set; }
        public Boolean Error { get; set; }

        public T Data { get; set; }

        public Response(string _menssage)
        {
            this.Error = true;
            this.Message = _menssage;
    
        }

        public Response(T _data, System.Net.HttpStatusCode _code)
        {
            this.Error = false;
            this.Data = _data;
        }
    }

    public class ResponseList<T>
    {
        public string Message { get; set; }
        public Boolean Error { get; set; }
        public List<T> Data { get; set; }

        public ResponseList(string _menssage)
        {
            this.Error = true;
            this.Message = _menssage;
        }

        public ResponseList(List<T> _data)
        {
            this.Error = false;
            this.Data = _data;
        }
    }
}
