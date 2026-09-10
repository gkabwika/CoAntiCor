
/*Call collectSecurityTelemetry(incidentRequestId) when the wizard starts or when submitted data.*/
async function collectSecurityTelemetry(incidentRequestId)
{
    const ua = navigator.userAgent;
    const lang = navigator.language;
    const platform = navigator.platform;
    const screenRes = `${screen.width}x${screen.height}`;
    const jsEnabled = true;
    const cookiesEnabled = navigator.cookieEnabled;
    const lsEnabled = !!window.localStorage;
    const timezoneOffset = new Date().getTimezoneOffset();

    const payload = {
        deviceOS: navigator.userAgentData?.platform || platform,
        browserName: "", // fill via UA parsing or UA-CH
        browserVersion: "",
        userAgentString: ua,
        screenResolution: screenRes,
        isMobileDevice: /Mobi|Android/i.test(ua),

        javascriptEnabled: jsEnabled,
        cookiesEnabled: cookiesEnabled,
        localStorageEnabled: lsEnabled,
        timezoneOffset: timezoneOffset,
        language: lang,
        platform: platform,
        referrerUrl: document.referrer,
        entryUrl: window.location.href,

        // basic session metadata
        firstAccessedAtUtc: new Date().toISOString(),
        lastAccessedAtUtc: new Date().toISOString(),
        submissionAttemptCount: 0,
        sessionDurationSeconds: 0,
        sessionId: crypto.randomUUID(),
        sessionReused: false
     };

     await fetch(`/api/security/${incidentRequestId}`, {
            method: "POST",
            headers: {"Content-Type": "application/json" },
            body: JSON.stringify(payload)
         });
    }

