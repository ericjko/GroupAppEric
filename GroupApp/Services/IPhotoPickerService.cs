using System;
using System.IO;
using System.Threading.Tasks;

namespace GroupApp.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
