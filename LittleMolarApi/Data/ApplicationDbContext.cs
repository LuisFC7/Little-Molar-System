using LittleMolarApi.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {
    public DbSet<Dentist> Dentist {get; set;}
    public DbSet<Patient> Patient {get; set;}
    public DbSet<Receipt> Receipts {get; set;}
    public DbSet<ClinicalHistory> ClinicalHistories {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options){

    }

    
}

