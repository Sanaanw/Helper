using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C_.Async.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public UserDetails Details { get; set; }
        public User ShallowCopy()
        {
            return this.MemberwiseClone() as User;
        }
        public User DeepCopy()
        {
            var result = JsonSerializer.SerializeToUtf8Bytes(this);
            return JsonSerializer.Deserialize<User>(result);
        }
        public override string ToString()
        {
            return Name + " " + Details.PhoneNumber;
        }
    }
}
