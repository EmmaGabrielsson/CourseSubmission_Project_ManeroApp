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
        if (videoContainer) {
            videoContainer.addEventListener('mouseover', () => playVideo(videoKey));
            videoContainer.addEventListener('mouseout', () => pauseVideo(videoKey));
        } else {
            console.error(`Element with class 'video-container-${videoKey}' not found.`);
        }
    });

    // Function to play the video
    function playVideo(videoKey) {
        const video = videos[videoKey];

        video.play().catch(error => {
            // Handle play() promise rejection due to autoplay policy
            console.error("Autoplay not allowed:", error);
        });
    }

    // Function to pause the video
    function pauseVideo(videoKey) {
        const video = videos[videoKey];
        video.pause();
    }

});