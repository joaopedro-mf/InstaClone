using InstaClone.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;

namespace InstaClone.Domain.ValueObjects
{
    [ComplexType]
    [Owned]
    public class Photo :ValueObject
    {
        //TODO 
        // ef core não consegue acessar metodos privados
        public string LocalStorage { get; set; }

        public Photo() { } 

        public Photo(string base64Photo, string nameUser)
        {

            if (base64Photo != "")
                SavePhoto(base64Photo, nameUser);
            else LocalStorage = "";
        }

        public Photo(string base64Photo, int idUser)
        {

            if (base64Photo != "")
                SavePhoto(base64Photo, idUser+'-'+new Random().Next().ToString());
            else LocalStorage = "";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return LocalStorage;
        }

        public void SavePhoto(string base64String, string nameofImage)
        {
            byte[] imageBytes;
            string localSave = $"db/image-{nameofImage}.png";

            try
            {
                imageBytes = Convert.FromBase64String(base64String);
                try
                {
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        using (var fs = new FileStream(localSave, FileMode.Create))
                        {
                            ms.WriteTo(fs);
                        }
                    }
                    LocalStorage = localSave;
                }
                catch
                {
                    AddError(new Error("Photo", " Não foi possível salvar a foto recebida "));
                }
            }
            catch
            {
                AddError(new Error("Photo", " Formato fornecido invalido "));
            }
            
            //var ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            //image =  Image.FromStream(ms, true);
            //image.Save(localSave, ImageFormat.Png);
        }

        public string GetPhoto()
        {
            try
            {
                FileStream fs = new FileStream(LocalStorage, FileMode.Open, FileAccess.Read);
                int length = Convert.ToInt32(fs.Length);
                byte[] data = new byte[length];
                fs.Read(data, 0, length);
                fs.Close();

                return Convert.ToBase64String(data);
            }
            catch
            {
                AddError(new Error("Photo", " Foto não existe"));
                return "";
            }
            
            
        }

    }
}
