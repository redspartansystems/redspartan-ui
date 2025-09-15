// RedSpartan UI JavaScript Interop
window.RedSpartanUI = {
    // Theme Management
    setTheme: function(theme) {
        document.documentElement.setAttribute('data-theme', theme);
        localStorage.setItem('rs-theme', theme);
        
        // Apply theme class to body
        document.body.className = document.body.className.replace(/theme-\w+/g, '');
        document.body.classList.add('theme-' + theme);
        
        console.log('RedSpartan UI: Theme set to', theme);
        
        // Dispatch custom event for theme change
        window.dispatchEvent(new CustomEvent('rs-theme-changed', { 
            detail: { theme: theme } 
        }));
    },

    getTheme: function() {
        const stored = localStorage.getItem('rs-theme');
        if (stored) return stored;
        
        // Auto-detect system theme
        if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
            return 'dark';
        }
        return 'light';
    },

    initializeTheme: function() {
        const theme = this.getTheme();
        this.setTheme(theme);
        
        // Listen for system theme changes
        if (window.matchMedia) {
            window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', (e) => {
                if (!localStorage.getItem('rs-theme')) {
                    this.setTheme(e.matches ? 'dark' : 'light');
                }
            });
        }
        
        return theme;
    },

    // Focus Management
    focusElement: function(elementId, delay = 0) {
        setTimeout(() => {
            const element = document.getElementById(elementId);
            if (element) {
                element.focus();
            }
        }, delay);
    }
};

// Initialize when DOM is loaded
document.addEventListener('DOMContentLoaded', function() {
    window.RedSpartanUI.initializeTheme();
    console.log('RedSpartan UI: JavaScript loaded and initialized');
});

// Initialize immediately if DOM is already loaded
if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', function() {
        window.RedSpartanUI.initializeTheme();
    });
} else {
    window.RedSpartanUI.initializeTheme();
}
