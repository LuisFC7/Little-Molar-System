using LittleMolarApi.DTO;
using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;

public interface IDentist{

    //Methods for IDentisi
    Task addDentist(DentistDto newDentist);
    // void addDentist(DentistDto newDentist);
    Task updateDentist(DentistDto dentist, int id);

    // Read all the dentist list
    Task<List<Dentist>> getAllDentist();

    bool usernameDentistExist(string username);
    bool emailDentistExist(string email);


    // Update data Dentist using idk

    // void deleteDentist(int dentistId);

}