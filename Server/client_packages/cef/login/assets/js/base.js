const loginRegex = /^([a-zA-Z\d_]{4,20})$/;
var registered = false;
var loginTries = 0;

/**
 * Image Slider
 */
function imageSlider() {
    let loginImages = jQuery(".login-left").children(".login-image");
    let index = 1;
    let length = loginImages.length;

    setInterval(() => {
        if (index === length) {
            index = 0;
        }

        var actualImage = loginImages[index];
        loginImages.removeClass("login-image--show");
        jQuery(actualImage).addClass("login-image--show");
        index++;
    }, 5000);
}

/**
 * Text Slider
 */
function textSlider() {
    let loginRules = jQuery(".login-rules").children();
    let index = 1;
    let length = loginRules.length;

    setInterval(function() {
        if (index === length) {
            index = 0;
        }

        var actualText = loginRules[index];
        loginRules.removeClass("rule-show");
        jQuery(actualText).addClass("rule-show");

        index++;
    }, 5000);
}

/**
 * Login response backend to UI.
 * Types:
 * 0 = OK
 * 1 = WARNING
 * 2 = ERROR
 * @param text
 * @param type
 */
function loginResponse(text, type) {
    type = parseInt(type);
    var responseElement = document.getElementById("response");

    /**
     * Remove show class to hide message
     */
    responseElement.classList.remove("show-response");

    /**
     * Add class to show message
     */
    setTimeout(() => {
        responseElement.classList.add("show-response");
    }, 150);

    /**
     * Remove all classes
     */
    responseElement.classList.remove("success", "warning", "error");

    switch (type) {
        case 0:
            responseElement.classList.add("success");
            break;
        case 1:
            responseElement.classList.add("warning");
            break;
        case 2:
            responseElement.classList.add("error");
            break;
        default:
            responseElement.classList.add("unknown");
            break;
    }

    /**
     * Set HTML Message
     */
    responseElement.innerHTML = text;
}

function loginCheck() {
    return loginTries < 5;
}

function handleLogin() {
    jQuery(".login-register-wrapper").on("submit", function(e) {
        e.preventDefault();
        loginResponse("", 1);

        var authType = jQuery(this).find("input[type=submit]:focus").data("type") === "register" ? 1 : 0;
        var username = jQuery("#username").val();

        if (loginTries < 5) {
            loginTries++;
        }

        if (!loginCheck()) {
            return loginResponse("nicht spammen.", 2);
        }

        if (!username.length) {
            return loginResponse("Name leer!", 1);
        }

        if (!loginRegex.test(username)) {
            return loginResponse("Mindestens 4 Zeichen.", 2);
        }

        if (authType === 1 && registered) {
            return loginResponse("Du hast dich bereits registriert.", 2);
        }

        /**
         * Call Register
         */
        if (authType === 0) {
            mp.trigger('Client:Login:tryLogin', username);
        }
    });
}

function setup() {
    /**
     * Removes the preload class which deactivates transitions etc.
     */
    jQuery("body").removeClass("preload");

    /**
     * Start the image slider logic
     */
    imageSlider();

    /**
     * Start the text slider logic
     */
    textSlider();

    handleLogin();

    var loginInterval = setInterval(function() {
        if (loginTries > 0) {
            loginTries--;
        }

    }, 1500);
}
setup();

function registerResult(type) {
    /**
     * If user got registered set registered to true.
     */
    if (type === 0) {
        registered = true;
    }
}