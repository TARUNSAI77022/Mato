using System.Collections;

namespace Mato.Service.WebApi.DTO
{
    public class ResponseClass
    {
        public int responsecode { get; set; }
        public string responsemessage { get; set; } = null!;
        public bool Issuccess { get; set; } = true;
        public object Res {  get; set; }=null!;
        //public ICollection Data { get; set; } = null!;
    }

}
