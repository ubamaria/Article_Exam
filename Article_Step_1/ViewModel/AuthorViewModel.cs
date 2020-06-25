using Article_Step_1.BindingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace Article_Step_1.ViewModel
{
    [DataContract]
    public class AuthorViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ArticleId { get; set; }
        [DataMember]
        [DisplayName("ФИО")]
        public string AuthorFIO { get; set; }
        [DataMember]

        public string Email { get; set; }
        [DataMember]

        public DateTime DateBirth { get; set; }
        [DataMember]

        public string Job { get; set; }
        [DataMember]
        public string Title { get; set; }
        public DateTime DateCreate { get; set; }

    }
}
