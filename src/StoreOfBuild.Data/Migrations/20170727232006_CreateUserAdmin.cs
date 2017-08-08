using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;
using StoreOfBuild.Data.Contexts;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace StoreOfBuild.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170727232006_CreateUserAdmin")]
    public partial class CreateUserAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"insert into [dbo].[AspNetRoles] values ('BD2AF962-6AB3-4D28-A902-0A8511750AB1', null, 'Admin', 'Admin');
                                insert into [dbo].[AspNetRoles] values ('813F9DB8-8601-4C82-BCE3-D122BC3E3AB9', null, 'Manager', 'Manager');
                                insert into [dbo].[AspNetRoles] values ('F2493BA0-B8CA-4E97-A882-DEA90B9E1728', null, 'Operation', 'Operation');");
            
            //@Axsd12 
            migrationBuilder.Sql(@"insert into [AspNetUsers] values
                ('6d9a6ca2-9d24-4ca2-ad4b-6265a818d7d4', 0, '7beea230-7f9d-4cd5-970b-37e9fa8f4347', 'admin@admin.com', 0, 1, null, 'ADMIN@ADMIN.COM', 'ADMIN@ADMIN.COM', 'AQAAAAEAACcQAAAAEIIWoviAu641wICvbFTecu/e8tUNiQXxYQ9JaEUXLYmdcSrSS6OnOmJg1U6kxQgGbQ==', null, 0, 'cebc5f87-b136-4c12-8dff-7bb65d499f35', 0, 'admin@admin.com')");

            migrationBuilder.Sql(@"insert into [AspNetUserRoles] values ('6d9a6ca2-9d24-4ca2-ad4b-6265a818d7d4', 'BD2AF962-6AB3-4D28-A902-0A8511750AB1')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
