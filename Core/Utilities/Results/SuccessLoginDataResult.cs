using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessLoginDataResult<T>:SuccessDataResult<T>
    {
        public int UserId { get;}
        public SuccessLoginDataResult(T data,string message,int id):base(data,message)
        {
            UserId = id;
        }

    }
}
