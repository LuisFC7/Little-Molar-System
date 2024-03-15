using LittleMolarApi.Models;

namespace LittleMolarApi.Interfaces;

public interface IDentist{

    //Methods for IDentisi
    void addDentist(Dentist newDentist);

    // Read all the dentist list
    List<Dentist> getAllDentist();

    // Update data Dentist using idk
    void updateDentist(Dentist dentist);

    void deleteDentist(int dentistId);

}