using System.Collections.ObjectModel;

namespace p2_projekt.models
{
    public interface ISailor
    {
        ObservableCollection<Travel> Travels { get; set; } // All travels. Old and new.
        ObservableCollection<Boat> Boats { get; set; } // boats owned
    }
}
