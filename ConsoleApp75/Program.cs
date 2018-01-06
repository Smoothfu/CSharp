﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp75
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("*****Fun with Lazy Instantiation*****\n");

            //This caller does not care about getting all songs but directllt created 10000 objects!
            MediaPlayer mPlayer = new MediaPlayer();
            mPlayer.Play();

            Console.ReadLine();

        }
    }

    //Represents a single song.
    class Song
    {
        public string Artist { get; set; }
        public string TrackName { get; set; }
        public double TrackLength { get; set; }

    }

    //Represents all songs on a player.
    class AllTracks
    {
        //Our media player can have a maximum of 10000 songs.
        private Song[] allSongs = new Song[10000];

        public AllTracks()
        {
            //Assume we fill up the array of Sony objects here.
            Console.WriteLine("Filling up the songs!\n");
        }
    }

    //The MediaPlayer has-an AllTracks object.
    class MediaPlayer
    {
        //Assume these methods do something useful.
        public void Play()
        {
            //Play a song
        }

        public void Pause()
        {
            //Pause the song.
        }

        public void Stop()
        {
            //Stop playback
        }

        private AllTracks allSongs = new AllTracks();

        public AllTracks GetAllTracks()
        {
            //return all of the songs.
            return allSongs;
        }
    }
}
