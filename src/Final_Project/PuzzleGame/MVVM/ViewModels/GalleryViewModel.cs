﻿using PuzzleGame.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PuzzleGame.Core;

namespace PuzzleGame.MVVM.ViewModels
{
    class GalleryViewModel : ObservableObject
    {
        Connection connection = new Connection();
        public List<Picture> _PictureList = new List<Picture>();

        public List<Picture> PictureList
        {
            get { return _PictureList; }
            set
            {
                _PictureList = value;
                OnPropertyChanged();
            }
        }

        public GalleryViewModel()
        {

            PictureList = new List<Picture>();

            LoadPicList();

        }

        void LoadPicList()
        {
            connection.dataAdapter = new SqlDataAdapter("Select * from PICTURE", connection.connStr);

            connection.dataAdapter.Fill(connection.ds, "PICTURE");
            connection.dt = connection.ds.Tables["PICTURE"];

            foreach (DataRow dr in connection.dt.Rows)
            {
                PictureList.Add(new Picture { Name = Convert.ToString(dr["PICNAME"]), Url = Convert.ToString(dr["PICPATH"]) });
            }
        }
    }
}
