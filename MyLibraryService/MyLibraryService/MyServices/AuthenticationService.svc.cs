﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MyLibraryService.MyServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticationService : IAuthenticationService
    {
        private LibraryMangEntities myservice=new LibraryMangEntities();

        public string GetName(int id)
        {
            throw new NotImplementedException();
        }

        public Administrator Login(string login, string password)
        {
           Administrator users= myservice.Administrators.Where(s => s.ad_login == login && s.ad_password == password).FirstOrDefault();
            return users;
        }

        public void register(Administrator admin)
        {
            myservice.Administrators.Add(admin);
        }
    }
}
