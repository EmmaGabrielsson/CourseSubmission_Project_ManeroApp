document.addEventListener("DOMContentLoaded", function () {

    // Get all video elements
    const videos = {
        kids: document.getElementById('myVideo-kids'),
        woman: document.getElementById('myVideo-woman'),
        men: document.getElementById('myVideo-men'),
        sport: document.getElementById('myVideo-sport'),
        bag: document.getElementById('myVideo-bag'),
        hat: document.getElementById('myVideo-hat'),
        shoes: document.getElementById('myVideo-shoes')

    };

    // Add event listeners for hover for each video container
    Object.keys(videos).forEach(videoKey => {
        const videoContainer = document.querySelector(`.video-container-${videoKey}`);

        videoContainer.addEventListener('mouseover', () => playVideo(videoKey));
        videoContainer.addEventListener('mouseout', () => pauseVideo(videoKey));
    });

    // Function to play the video
    function playVideo(videoKey) {
        videos[videoKey].play();
    }

    // Function to pause the video
    function pauseVideo(videoKey) {
        videos[videoKey].pause();
    }

});