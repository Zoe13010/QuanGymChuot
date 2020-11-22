using System;
using System.Collections.Generic;
using System.Text;

namespace QuanGymChuot.Library
{
    public struct Result
    {
        /// <summary>
        /// Kiểm tra hàm đã thực hiện thành công hay chưa.
        /// </summary>
        public bool Completed;

        /// <summary>
        /// Tin nhắn truyền vào từ hàm nếu có.
        /// </summary>
        public object Message;

        /// <summary>
        /// Tạo một thông báo mới có nội dung của hàm truyền vào hiện tại.
        /// </summary>
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