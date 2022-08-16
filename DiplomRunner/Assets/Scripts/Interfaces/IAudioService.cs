namespace Interfaces
{
    public interface IAudioService
    {
       void Play(string soundName);
        void Stop(string soundName);
        float Volume { get; set; }
        bool Mute { get; set; }

    }
}