let scrollToTopComponent = null;
let scrollListener = null;

export function initialize(dotnetHelper) {
    scrollToTopComponent = dotnetHelper;
    
    // Add scroll listener to track scroll position
    scrollListener = function() {
        const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
        const shouldShow = scrollTop > 300; // Show after scrolling 300px
        
        if (scrollToTopComponent) {
            scrollToTopComponent.invokeMethodAsync('UpdateVisibility', shouldShow);
        }
    };
    
    window.addEventListener('scroll', scrollListener, { passive: true });
    
    // Initial check
    scrollListener();
}

export function dispose() {
    if (scrollListener) {
        window.removeEventListener('scroll', scrollListener);
        scrollListener = null;
    }
    scrollToTopComponent = null;
}