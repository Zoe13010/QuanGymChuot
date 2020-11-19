using System;
using System.Collections.Generic;
using System.Text;

namespace QuanGymChuot.Library
{
    public struct Result
    {
        public bool Completed;
        public object Message;
        public Result Clone()
        {
            return new Result()
            {
                Completed = this.Completed,
                Message = this.Message
            };
        }
    }
}