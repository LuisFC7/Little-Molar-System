using LittleMolarApi.DTO;
using LittleMolarApi.Interfaces;
using LittleMolarApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using LittleMolarApi.Utilities;

namespace LittleMolarApi.Services;

public class DentistService : IDentist{

    private readonly ApplicationDbContext _context;
    private readonly UtilitiesServices _auxServices;

    public DentistService(ApplicationDbContext context, UtilitiesServices auxServices){
        _context = context;
        _auxServices = auxServices;
    }
   

    public async Task addDentist(DentistDto newDentistDto){

        string securePass = _auxServices.hashPassword(newDentistDto.dentistPassword);
        Console.WriteLine(newDentistDto.dentistPassword);
        Console.WriteLine(securePass);


        var newDentist = new Dentist(
            newDentistDto.dentistName,
            newDentistDto.dentistLastName,
            newDentistDto.dentistUser,
            securePass,
            newDentistDto.dentistEmail,
            newDentistDto.dentistAge,
            newDentistDto.dentistId,
            newDentistDto.dentistPhone
        );
        _context.Dentist.Add(newDentist);
        await _context.SaveChangesAsync();
    }

    public async Task updateDentist(DentistUpDto updatedDentistDto){

        if(updatedDentistDto == null)
            throw new NotImplementedException();

        var dentist = await _context.Dentist.FindAsync(updatedDentistDto.id);

        if(dentist == null)
            throw new NotImplementedException();

        var isUnique = await _context.Dentist
            .Where(d=> ( d.dentistEmail == updatedDentistDto.dentistEmail || d.dentistUser == updatedDentistDto.dentistUser) && d.id !=updatedDentistDto.id )
            .AnyAsync();

        if(!isUnique){
            dentist.dentistName = updatedDentistDto.dentistName;
            dentist.dentistLastName = updatedDentistDto.dentistLastName;
            dentist.dentistUser = updatedDentistDto.dentistUser;
            dentist.dentistPassword = updatedDentistDto.dentistPassword;
            dentist.dentistEmail = updatedDentistDto.dentistEmail;
            dentist.dentistAge = updatedDentistDto.dentistAge;
            dentist.dentistId = updatedDentistDto.dentistId;
            dentist.dentistPhone = updatedDentistDto.dentistPhone;

            await _context.SaveChangesAsync();
        }else
            throw new InvalidOperationException("El correo electronico o usuario actualizado ya se encuentra registrado.");
        
    }
    public async Task createPatient(PatientDTO patient){
        if(patient==null)
            throw new NotImplementedException();

        var newPatient = new Patient(
            patient.patientName,
            patient.patientLastName,
            patient.patientAge,
            patient.patientPhone,
            patient.dentistId
        );
        

        _context.Patient.Add(newPatient);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Patient>> getAllPatients(){
        try{
           return await _context.Patient.ToListAsync();
        }
        catch (Exception ex){
            throw ex;
        }
    }
    public bool validateExistence(string table, string field, string check){
        return _auxServices.fieldExist(table, field, check);
    }


    //    public void deleteDentist(int dentistId){

    //     var dentistDelete = _dentist.FirstOrDefault(d => d.id == dentistId);

    //     if(dentistDelete != null){
    //         _dentist.Remove(dentistDelete);
    //     }

    //    }
}