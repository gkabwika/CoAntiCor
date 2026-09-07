window.draftStorage = {
    saveDraftId: function (id) {
        localStorage.setItem("coanticor_draft", id);
    },
    getDraftId: function () {
        return localStorage.getItem("coanticor_draft");
    },
    clearDraft: function () {
        localStorage.removeItem("coanticor_draft");
    }
};