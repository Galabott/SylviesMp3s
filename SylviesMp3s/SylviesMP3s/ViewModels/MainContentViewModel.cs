using MarthaService;
using NAudio.MediaFoundation;
using SylviesMp3s.Commands;
using SylviesMp3s.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace SylviesMp3s.ViewModels
{
    public class MainContentViewModel : BaseViewModel
    {
        private BaseViewModel leftViewModel;

        public ObservableCollection<Playlists> UserPlaylists = new ObservableCollection<Playlists>();
        public ObservableCollection<Tunes> SelectedPlaylistSongs = new ObservableCollection<Tunes>();
        public ObservableCollection<Playlists> PublicPlaylists = new ObservableCollection<Playlists>();
        public ObservableCollection<Playlists> UserAlbums = new ObservableCollection<Playlists>();


        public MarthaProcessor _db = MarthaProcessor.Instance;

        //A METTRE A -1 ET CHANGER LORS CONNECTION...
        //public int CurrentUserID { get; set; } = -1;
        public int CurrentUserID { get; set; } = 1;

        public BaseViewModel LeftViewModel
        {
            get { return leftViewModel; }
            set
            {
                leftViewModel = value;
                OnPropertyChanged();
            }
        }

        private BaseViewModel centralViewModel;

        public BaseViewModel CentralViewModel
        {
            get { return centralViewModel; }
            set
            {
                centralViewModel = value;
                OnPropertyChanged();
            }
        }
        private BaseViewModel upperViewModel;

        public BaseViewModel UpperViewModel
        {
            get { return upperViewModel; }
            set
            {
                upperViewModel = value;
                OnPropertyChanged();
            }
        }

        ListPlayListViewModel listPlayListViewModel;
        PlayListViewModel playListViewModel;
        PlayerViewModel playerViewModel;
        AlbumViewModel albumViewModel;
        PublicPlaylistViewModel publicPlaylistViewModel;

        public MainViewModel mvm { get; set; }


        public RelayCommand ChangeLeftViewPlayList { get; private set; }
        public RelayCommand ChangeLeftViewAlbum { get; private set; }
        public RelayCommand ChangeLeftViewPublic { get; private set; }


        public MainContentViewModel( MainViewModel mvm)
        {
            listPlayListViewModel = new ListPlayListViewModel(this);
            playListViewModel = new PlayListViewModel(this);
            playerViewModel = new PlayerViewModel(this);
            albumViewModel = new AlbumViewModel(this);
            publicPlaylistViewModel = new PublicPlaylistViewModel(this);

            LeftViewModel = listPlayListViewModel;
            CentralViewModel = playListViewModel;
            UpperViewModel = playerViewModel;

            this.mvm = mvm;


            ChangeLeftViewPlayList = new RelayCommand(ChangeLeftViewPL);
            ChangeLeftViewAlbum = new RelayCommand(ChangeLeftViewA);
            ChangeLeftViewPublic = new RelayCommand(ChangeLeftViewP);


            //TEST DB
            LoadSongs(1);
            LoadUserPlaylists();
            LoadPublicPlaylists();
            LoadUserAlbums();
        }

        public int currentPlaylistId;
        public void ChangeCurrentPlayList(int playlistid)
        {
            currentPlaylistId = playlistid;
            SelectedPlaylistSongs.Clear();
            LoadSongs(playlistid);
            CentralViewModel= new PlayListViewModel(this);
        }

        private void RefreshList()
        {
            UserPlaylists = new ObservableCollection<Playlists>();
            UserAlbums = new ObservableCollection<Playlists>();

            LoadUserPlaylists();
            LoadUserAlbums();

            listPlayListViewModel.PPlaylists = UserPlaylists;
            albumViewModel.PPlaylists = UserAlbums;
        }
        private void RefreshSongs(int id)
        {
            SelectedPlaylistSongs = new ObservableCollection<Tunes>();

            LoadSongs(id);

            playListViewModel.Songs = SelectedPlaylistSongs;
        }

        private void RefreshPublicList()
        {
            PublicPlaylists = new ObservableCollection<Playlists>();

            LoadPublicPlaylists();

            publicPlaylistViewModel.PPlaylists = PublicPlaylists;
        }


        public async void LoadSongs(int playlistid)
        {
            if (CurrentUserID != -1)
            {
                JsonObject b = new JsonObject();
                b.Add("playlistid", playlistid);
                b.Add("userid", CurrentUserID);
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("select-songs-from-playlist", b);

                List<Tunes> lol = new List<Tunes>();

                lol = MarthaResponseConverter<Tunes>.Convert(mresponse);

                foreach (Tunes m in lol)
                {
                    SelectedPlaylistSongs.Add(m);
                }
            }
        }

        public async void AddPlaylist(JsonObject playlist)
        {
            if (CurrentUserID != -1)
            {

                //JsonObject playlist = new JsonObject();
                //playlist.Add("artist", null);
                //playlist.Add("genre", null);
                //playlist.Add("title", "Liked Playlist");
                //playlist.Add("year", null);
                //playlist.Add("is_public", false);
                //playlist.Add("id_user", mcvm.CurrentUserID);
                //playlist.Add("album_cover", null);
                //mcvm.AddPlaylist(playlist);


                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("insert-playlist", playlist);

                RefreshList();
            }
        }

        public async void AddPublicPlaylist(JsonObject playlist, int playlist_id)
        {
            if (CurrentUserID != -1)
            {

                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("insert-playlist", playlist);

                RefreshList();

                //Load songs from Copied Public Playlist
                JsonObject b = new JsonObject();
                b.Add("playlistid", playlist_id);
                mresponse = new MarthaResponse(); 
                mresponse = await _db.ExecuteQueryAsync("select-songs-from-public-playlist", b);

                List<Playlists_tunes> Ptunes = new List<Playlists_tunes>();

                Ptunes = MarthaResponseConverter<Playlists_tunes>.Convert(mresponse);

                //Copy songs from copied public playlist
                foreach (Playlists_tunes m in Ptunes)
                {
                    JsonObject c = new JsonObject();
                    c.Add("id_tune", m.Id_Tune);
                    c.Add("id_playlist", UserPlaylists.Last().Id);
                    mresponse = new MarthaResponse();
                    mresponse = await _db.ExecuteQueryAsync("insert-tune-playlist", c);
                }

                RefreshList();
            }
        }

        public async void DelPlaylist(JsonObject playlist)
        {
            if (CurrentUserID != -1)
            {
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("delete-playlist", playlist);

                RefreshList();
            }
        }
        public async void SavePlaylist(JsonObject playlist)
        {
            if (CurrentUserID != -1)
            {
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("update-playlist", playlist);

                RefreshList();
            }
        }

        public async void LoadPublicPlaylists()
        {
            if (CurrentUserID != -1)
            {
                JsonObject b = new JsonObject();
                b.Add("userid", CurrentUserID);
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("select-all-public-playlists", b);

                List<Playlists> lol = new List<Playlists>();

                lol = MarthaResponseConverter<Playlists>.Convert(mresponse);

                foreach (Playlists m in lol)
                {
                    PublicPlaylists.Add(m);
                }
            }


            // Console.WriteLine(lol.First().Title);
        }

        public async void LoadUserPlaylists()
        {
            if (CurrentUserID != -1)
            {
                JsonObject b = new JsonObject();
                b.Add("userid", CurrentUserID);
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("select-playlists-from-user", b);

                List<Playlists> lol = new List<Playlists>();

                lol = MarthaResponseConverter<Playlists>.Convert(mresponse);

                foreach (Playlists m in lol)
                {
                    UserPlaylists.Add(m);
                }
            }
        }

        public async void LoadUserAlbums()
        {
            if (CurrentUserID != -1)
            {
                JsonObject b = new JsonObject();
                b.Add("userid", CurrentUserID);
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("select-album-from-user", b);

                List<Playlists> lol = new List<Playlists>();

                lol = MarthaResponseConverter<Playlists>.Convert(mresponse);

                foreach (Playlists m in lol)
                {
                    UserAlbums.Add(m);
                }
            }
        }

        private void ChangeLeftViewPL(object nothig)
        {
            listPlayListViewModel.SelectedPlaylist = null;
            LeftViewModel = listPlayListViewModel;
        }
        private void ChangeLeftViewA(object nothig)
        {
            albumViewModel.SelectedPlaylist = null;
            LeftViewModel = albumViewModel;
        }
        private void ChangeLeftViewP(object nothig)
        {
            LeftViewModel = publicPlaylistViewModel;
        }

        public void changeParentViewModel(BaseViewModel newView)
        {
            mvm.CurrentViewModel = newView;
        }
        public void changeLeftView(BaseViewModel newView)
        {
            LeftViewModel= newView;
        }
        public void changeUpperView(BaseViewModel newView)
        {
            UpperViewModel = newView;
        }
        public void changeCentralView(BaseViewModel newView)
        {
            CentralViewModel = newView;
        }

        public async Task SaveSongAsync(JsonObject song)
        {
            if (CurrentUserID != -1)
            {
                MarthaResponse mresponse = new MarthaResponse();
                mresponse = await _db.ExecuteQueryAsync("update-song", song);
                int playlistId = currentPlaylistId;

                RefreshSongs(playlistId);
            }
        }

        public async void DelSongAsync(JsonObject tune)
        {
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("delete-tune-playlist", tune);
            int playlistId = currentPlaylistId;

            RefreshSongs(playlistId);
        }

        public async void AddSongAsync(JsonObject song)
        {
            MarthaResponse mresponse = new MarthaResponse();
            mresponse = await _db.ExecuteQueryAsync("insert-song", song);

            JsonObject b = new JsonObject();
            MarthaResponse mresponse2 = new MarthaResponse();
            mresponse2 = await _db.ExecuteQueryAsync("select-tunes", b);

            List<Tunes> tunes = new List<Tunes>();

            tunes = MarthaResponseConverter<Tunes>.Convert(mresponse2);

            int lastTuneId = tunes[0].Id;
            int playlistId = currentPlaylistId;

            JsonObject tunePlaylist = new JsonObject
            {
                { "id_tune", lastTuneId },
                { "id_playlist",  playlistId}
            };

            MarthaResponse mresponse3 = new MarthaResponse();
            mresponse3 = await _db.ExecuteQueryAsync("insert-tune-playlist", tunePlaylist);

            RefreshSongs(playlistId);
        }
    }
    
}

