using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TicTacToeWeb.Models
{
    public class TicTacToeDbContext :DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}