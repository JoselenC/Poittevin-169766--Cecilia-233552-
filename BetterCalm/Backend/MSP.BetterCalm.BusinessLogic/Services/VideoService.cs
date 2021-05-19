using System.Collections.Generic;
using MSP.BetterCalm.BusinessLogic.Exceptions;
using MSP.BetterCalm.Domain;

namespace MSP.BetterCalm.BusinessLogic
{
    public class VideoService: IVideoService

    {
    private ManagerVideoRepository repository;

    public VideoService(ManagerVideoRepository vRepository)
    {
        repository = vRepository;
    }

    public List<Video> GetVideos()
    {
        List<Video> videos = new List<Video>();
        foreach (var Video in repository.Videos.Get())
        {
            if (!Video.AssociatedToPlaylist)
                videos.Add(Video);
        }

        return videos;
    }

    private bool AlreadyexistVideo(Video video)
    {
        try
        {
            repository.Videos.FindById(video.Id);
            return true;
        }
        catch (KeyNotFoundException)
        {
            return false;
        }
    }

    public Video SetVideo(Video video)
    {
        if (!AlreadyexistVideo(video))
            return repository.Videos.Add(video);

        throw new AlreadyExistVideo();
    }

    public List<Video> GetVideosByName(string videoName)
    {
        List<Video> videos = new List<Video>();
        foreach (var video in repository.Videos.Get())
        {
            if (video.IsSameVideoName(videoName) && !video.AssociatedToPlaylist)
                videos.Add(video);
        }

        if (videos.Count == 0)
            throw new NotFoundVideo();
        return videos;
    }

    public List<Video> GetVideosByAuthor(string creatorName)
    {
        List<Video> videos = new List<Video>();
        foreach (var video in repository.Videos.Get())
        {
            if (video.IsSameCreatorName(creatorName) && !video.AssociatedToPlaylist)
                videos.Add(video);
        }

        if (videos.Count == 0)
            throw new NotFoundVideo();
        return videos;
    }

    public List<Video> GetVideosByCategoryName(string categroyName)
    {
        List<Video> videos = new List<Video>();
        foreach (Video video in repository.Videos.Get())
        {
            if (video.IsSameCategoryName(categroyName) && !video.AssociatedToPlaylist)
                videos.Add(video);
        }

        if (videos.Count == 0)
            throw new NotFoundVideo();
        return videos;
    }

    public void UpdateVideoById(int id, Video videoUpdated)
    {
        try
        {
            Video videoToUpdate = repository.Videos.FindById(id);
            repository.Videos.Update(videoToUpdate, videoUpdated);
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundVideo();
        }
    }

    public void DeleteVideo(int id)
    {
        try
        {
            Video videoToDelete = repository.Videos.FindById(id);
            repository.Videos.Delete(videoToDelete);
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundVideo();
        }
    }

    public Video GetVideoById(int id)
    {
        try
        {
            Video video = repository.Videos.FindById(id);
            if (!video.AssociatedToPlaylist)
                return video;
            throw new NotFoundId();
        }
        catch (KeyNotFoundException)
        {
            throw new NotFoundId();
        }
    }
    }
}