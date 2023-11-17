document.addEventListener("DOMContentLoaded", function () {

    const videos = {
        kids: document.getElementById('myVideo-kids'),
        woman: document.getElementById('myVideo-woman'),
        men: document.getElementById('myVideo-men'),
        sport: document.getElementById('myVideo-sport'),
        bag: document.getElementById('myVideo-bag'),
        hat: document.getElementById('myVideo-hat'),
        shoes: document.getElementById('myVideo-shoes')
    };

    Object.keys(videos).forEach(videoKey => {
        const videoContainer = document.querySelector(`.video-container-${videoKey}`);
        if (videoContainer) {
            const video = videos[videoKey];
            if (video) {
                // Use 'mouseover' for desktop
                videoContainer.addEventListener('mouseover', () => playVideo(videoKey));

                // Use 'click' for mobile
                if ('ontouchstart' in document.documentElement) {
                    videoContainer.addEventListener('click', (event) => {
                        event.preventDefault(); // Prevent navigation on click for mobiles
                        playVideo(videoKey);
                    });
                }

                videoContainer.addEventListener('mouseout', () => pauseVideo(videoKey));
            } else {
                console.error(`Video element with id 'myVideo-${videoKey}' not found.`);
            }
        }
    });

    function playVideo(videoKey) {
        const video = videos[videoKey];
        if (video) {
            video.play().catch(error => {
                console.error("Autoplay not allowed:", error);
            });
        }
    }

    function pauseVideo(videoKey) {
        const video = videos[videoKey];
        if (video) {
            video.pause();
        }
    }

});
