using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Store.Models
{
    public class AppUser: IdentityUser
    {
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Recycler> Recyclers { get; set; }
        // Здесь будут указываться дополнительные свойства
    }
}