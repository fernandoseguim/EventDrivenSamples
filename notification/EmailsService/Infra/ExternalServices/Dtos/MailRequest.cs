using System;
using System.Collections.Generic;

namespace EmailsService.Infra.ExternalServices.Dtos
{
    public class MailRequest
    {
        public MailRequest(Guid messageId, Addressing @from, Addressing to, Template template)
        {
            MessageId = messageId;
            From = @from;
            To = to;
            Template = template;
        }

        public Guid MessageId { get; }
        public Addressing From { get; }
        public Addressing To { get; }
        public Template Template { get; }
    }
    
    public struct Addressing
    {
        public Addressing(string email, string name)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Email { get; }

        public string Name { get; }
    }
    
    public struct Template
    {
        public Template(string id, IDictionary<string, string> data)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id)); 
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public string Id { get; }
        public IDictionary<string, string> Data { get; }
    }
}