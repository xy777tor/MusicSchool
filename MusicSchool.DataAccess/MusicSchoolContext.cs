using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchool.DataAccess;
public class MusicSchoolContext : DbContext
{
    public MusicSchoolContext(DbContextOptions<MusicSchoolContext> options) : base(options)
    {

    }

    public DbSet<EventWindow> eventWindows { get; set; }
}
