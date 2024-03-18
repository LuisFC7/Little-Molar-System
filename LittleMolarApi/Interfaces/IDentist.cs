using LittleMolarApi.DTO;
using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;

public interface IDentist{

    //Methods for IDentisi
    Task addDentist(DentistDto newDentist);
    // void addDentist(DentistDto newDentist);
    Task updateDentist(DentistUpDto dentist);

    Task createPatient(PatientDTO patient);

    // Read all the dentist list
    Task<List<Patient>> getAllPatients();

    bool validateExistence(string table, string field, string username);


    // Update data Dentist using idk

    // void deleteDentist(int dentistId);

}