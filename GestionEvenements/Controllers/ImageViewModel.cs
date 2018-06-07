using BoEvents;
using GestionEvenements.Models;
using Service;
using System;
using System.Collections.Generic;

namespace GestionEvenements.Controllers
{
    public class ImageViewModel : ViewModel<Image>
    {
        public ImageViewModel()
        {
            this.Metier = new Image();
        }
        public ImageViewModel(Image i)
        {
            this.Metier = i;

        }

        public string Path
        {
            get { return this.Metier.Path; }
            set { Metier.Path = value; }
        }

        public string Fichier
        {
            get { return this.Metier.Fichier; }
            set { Metier.Fichier = value; }
        }
        
        public void Save()
        {
            this.ID = Guid.NewGuid();
            ServiceImage.Insert(this.Metier);
        }

        public static List<ImageViewModel> GetAll()
        {
            List<ImageViewModel> retour = new List<ImageViewModel>();


            List<Image> images = ServiceImage.GetAll();
            foreach (Image i in images)
            {
                retour.Add(new ImageViewModel(i));
            }

            return retour;
        }

        public static ImageViewModel Get(Guid? id)
        {
            ImageViewModel retour = null;

            if (id.HasValue)
            {
                retour = new ImageViewModel(ServiceImage.Get(id.Value));
            }
            else
            {
                Image i = new Image() { ID = Guid.Empty };
                retour = new ImageViewModel(i);
            }

            return retour;
        }
    }
}