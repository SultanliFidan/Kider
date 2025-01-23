﻿using KidKinder.Enums;

namespace KidKinder.Extensions
{
    public static class RoleExtension
    {
        public static string GetRole(this Roles role)
        {
            return role switch
            {

                Roles.Admin => nameof(Roles.Admin),
                Roles.User => nameof(Roles.User)

            };

        }
    }
}
