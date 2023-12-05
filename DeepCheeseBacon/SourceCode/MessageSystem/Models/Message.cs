using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace deepcheesebacon
{
    public class Message
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public string content { get; set; }
        public string title { get; set; }
        public DateTime sentAt { get; set; }
        public bool isChecked { get; set; }

        public override string ToString()
        {
            DBManager db = DBManager.GetInstance();

            string senderEmail = db.GetEmailByUserId(senderId);
            if(senderEmail == null) 
            {
                return "보낸 사람을 찾을 수 없는 메시지입니다.";
            }
            string isCheck = null;
            if(isChecked == true)
            {
                isCheck = "확인함";
            }else if(isChecked == false)
            {
                isCheck = "확인 안함";
            }

            return $"보낸사람: {senderEmail} || 제목: {title} || 내용: {content} || 확인 여부: {isCheck}";
        }
    }

    
}
