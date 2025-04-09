document.addEventListener("DOMContentLoaded", function () {
    // ---- XỬ LÝ CHUYỂN TAB ----
    document.querySelectorAll(".tab").forEach((tab) => {
        tab.addEventListener("click", function () {
            document.querySelectorAll(".tab").forEach((t) => t.classList.remove("active"));
            this.classList.add("active");

            let filter = this.getAttribute("data-filter");
            document.querySelectorAll(".movie-list").forEach((list) => {
                list.classList.add("hidden");
            });

            if (filter === "all") {
                document.querySelector(".movie-list.default").classList.remove("hidden");
            } else {
                document.getElementById(filter).classList.remove("hidden");
            }
        });
    });

    // ---- XỬ LÝ MUA VÉ ----
    document.querySelectorAll(".buy-button").forEach(button => {
        button.addEventListener("click", function (e) {
            e.stopPropagation();
            const movieName = this.closest(".movie-item").querySelector(".movie-name").textContent;
            window.location.href = "/Home/MuaVe?ten=" + encodeURIComponent(movieName);
        });
    });

    // ---- XỬ LÝ XEM CHI TIẾT PHIM ----
    document.querySelectorAll(".chitietphim-button").forEach(button => {
        button.addEventListener("click", function (e) {
            e.stopPropagation();
            const movieName = this.closest(".movie-item").querySelector(".movie-name").textContent;
            window.location.href = "/Home/Chitietphim?ten=" + encodeURIComponent(movieName);
        });
    });

    // ---- CLICK VÀO POSTER -> CHI TIẾT PHIM ----
    document.querySelectorAll(".poster-container").forEach(poster => {
        poster.addEventListener("click", function (e) {
            if (!e.target.classList.contains("buy-button")) {
                const movieName = this.closest(".movie-item").querySelector(".movie-name").textContent;
                window.location.href = "/Home/Chitietphim?ten=" + encodeURIComponent(movieName);
            }
        });
    });
});
