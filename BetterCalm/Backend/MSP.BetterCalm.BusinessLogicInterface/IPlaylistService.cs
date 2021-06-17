using System.Collections.Generic;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogicInterface
{
    public interface IPlaylistService
    {
        public List<Playlist> GetPlaylist();
        public Playlist SetPlaylist(Playlist playlist);
        public List<Playlist> GetPlaylistByName(string playlistName);
        public List<Playlist> GetPlaylistByContentName(string ContentName); 
        public List<Playlist> GetPlaylistByCategoryName(string categoryName);
        public Playlist GetPlaylistById(int id);
        public void UpdatePlaylist(Playlist playlistToUpdate, Playlist newPlaylist);
        public void UpdatePlaylistById(int id, Playlist newPlaylist);
        public void DeletePlaylist(int id);
        public Content AddNewContentToPlaylist(Content content, int idPlaylist);
        public Playlist AssociateContentToPlaylist(int idContent, int idPlaylist);
    }
}