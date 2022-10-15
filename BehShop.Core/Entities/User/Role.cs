﻿namespace BehShop.Domain.Entities.User
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
