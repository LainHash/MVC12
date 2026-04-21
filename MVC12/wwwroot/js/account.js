/* ===== Account Auth & Profile JavaScript ===== */

(function () {
  "use strict";

  /**
   * Initialize Account Handlers
   */
  function initAccountHandlers() {
    setupPasswordToggle();
    setupAuthFormValidation();
    setupProfileFormValidation();
    setupFormAnimations();
    setupPasswordStrengthIndicator();
  }

  /**
   * Setup Password Toggle Visibility
   */
  function setupPasswordToggle() {
    const toggleButtons = document.querySelectorAll(".btn-toggle-password");

    toggleButtons.forEach((btn) => {
      btn.addEventListener("click", function (e) {
        e.preventDefault();

        const passwordField = this.parentElement.querySelector(
          'input[type="password"], input[type="text"]',
        );
        if (!passwordField) return;

        const isPassword = passwordField.type === "password";

        // Toggle input type
        passwordField.type = isPassword ? "text" : "password";

        // Toggle icon
        const icon = this.querySelector("i");
        if (icon) {
          icon.classList.toggle("fa-eye");
          icon.classList.toggle("fa-eye-slash");
        }

        // Focus back to input
        passwordField.focus();
      });
    });
  }

  /**
   * Setup Auth Form Validation
   */
  function setupAuthFormValidation() {
    const authForms = document.querySelectorAll(".auth-form");

    authForms.forEach((form) => {
      // Real-time validation
      const inputs = form.querySelectorAll("input[required], select[required]");
      inputs.forEach((input) => {
        input.addEventListener("blur", function () {
          validateField(this);
        });

        input.addEventListener("change", function () {
          if (form.classList.contains("was-validated")) {
            validateField(this);
          }
        });
      });

      // Form submission
      form.addEventListener("submit", function (e) {
        if (!form.checkValidity()) {
          e.preventDefault();
          e.stopPropagation();
          showNotification(
            "Vui lòng điền đầy đủ tất cả các trường bắt buộc",
            "danger",
          );
        }
        form.classList.add("was-validated");
      });

      // Add animation to form groups
      const formGroups = form.querySelectorAll(".form-group-auth");
      formGroups.forEach((group, index) => {
        group.style.animationDelay = `${index * 0.05}s`;
      });
    });
  }

  /**
   * Setup Profile Form Validation
   */
  function setupProfileFormValidation() {
    const profileForm = document.querySelector(".profile-form");
    if (!profileForm) return;

    // Real-time validation
    const inputs = profileForm.querySelectorAll(
      "input[required], select[required]",
    );
    inputs.forEach((input) => {
      input.addEventListener("blur", function () {
        validateField(this);
      });

      input.addEventListener("change", function () {
        if (profileForm.classList.contains("was-validated")) {
          validateField(this);
        }
      });
    });

    // Form submission
    profileForm.addEventListener("submit", function (e) {
      if (!profileForm.checkValidity()) {
        e.preventDefault();
        e.stopPropagation();
        showNotification(
          "Vui lòng điền đầy đủ tất cả các trường bắt buộc",
          "danger",
        );
      }
      profileForm.classList.add("was-validated");
    });

    // Add animation to profile sections
    const sections = profileForm.querySelectorAll(".profile-section");
    sections.forEach((section, index) => {
      section.style.animationDelay = `${index * 0.1}s`;
    });
  }

  /**
   * Validate individual field
   */
  function validateField(field) {
    const isValid = field.checkValidity();

    if (isValid) {
      field.classList.remove("is-invalid");
      field.classList.add("is-valid");
    } else {
      field.classList.remove("is-valid");
      field.classList.add("is-invalid");
    }
  }

  /**
   * Setup Password Strength Indicator
   */
  function setupPasswordStrengthIndicator() {
    const passwordInputs = document.querySelectorAll(
      'input[type="password"][asp-for*="Password"]',
    );

    passwordInputs.forEach((input) => {
      // Create strength indicator if doesn't exist
      if (!input.nextElementSibling?.classList.contains("password-strength")) {
        const indicator = document.createElement("div");
        indicator.className =
          "password-strength mt-2 p-2 rounded small text-muted";
        input.parentElement.appendChild(indicator);

        input.addEventListener("input", function () {
          const strength = calculatePasswordStrength(this.value);
          updateStrengthIndicator(indicator, strength);
        });
      }
    });
  }

  /**
   * Calculate password strength
   */
  function calculatePasswordStrength(password) {
    let strength = 0;

    if (password.length >= 8) strength++;
    if (password.length >= 12) strength++;
    if (/[a-z]/.test(password)) strength++;
    if (/[A-Z]/.test(password)) strength++;
    if (/\d/.test(password)) strength++;
    if (/[!@#$%^&*]/.test(password)) strength++;

    return strength;
  }

  /**
   * Update strength indicator
   */
  function updateStrengthIndicator(indicator, strength) {
    const labels = [
      { text: "Rất yếu", color: "bg-danger", width: "20%" },
      { text: "Yếu", color: "bg-warning", width: "40%" },
      { text: "Trung bình", color: "bg-info", width: "60%" },
      { text: "Mạnh", color: "bg-success", width: "80%" },
      { text: "Rất mạnh", color: "bg-success", width: "100%" },
      { text: "Cực kỳ mạnh", color: "bg-success", width: "100%" },
    ];

    const label = labels[Math.min(strength, 5)];

    indicator.innerHTML = `
      <div class="d-flex justify-content-between mb-2">
        <span>Độ mạnh mật khẩu:</span>
        <strong>${label.text}</strong>
      </div>
      <div class="progress" style="height: 6px;">
        <div class="progress-bar ${label.color}" role="progressbar" style="width: ${label.width}" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100"></div>
      </div>
    `;
  }

  /**
   * Setup Form Animations
   */
  function setupFormAnimations() {
    const authCards = document.querySelectorAll(".auth-card");
    const profileCards = document.querySelectorAll(".profile-card");

    const cards = [...authCards, ...profileCards];

    cards.forEach((card, index) => {
      card.style.animation = `fadeInUp 0.6s ease-out`;
      card.style.animationDelay = `${index * 0.1}s`;
      card.style.animationFillMode = "both";
    });

    // Intersection Observer for profile sidebar
    const profileSidebar = document.querySelector(".profile-sidebar");
    if (profileSidebar && "IntersectionObserver" in window) {
      const observer = new IntersectionObserver(
        (entries) => {
          entries.forEach((entry) => {
            if (entry.isIntersecting) {
              entry.target.classList.add("in-view");
            }
          });
        },
        { threshold: 0.1 },
      );

      observer.observe(profileSidebar);
    }
  }

  /**
   * Setup Remember Me Functionality
   */
  function setupRememberMe() {
    const rememberCheckbox = document.getElementById("rememberMe");
    const emailInput = document.querySelector('input[name="email"]');

    if (rememberCheckbox && emailInput) {
      // Load saved email
      const savedEmail = localStorage.getItem("remembered_email");
      if (savedEmail) {
        emailInput.value = savedEmail;
        rememberCheckbox.checked = true;
      }

      // Save email on change
      rememberCheckbox.addEventListener("change", function () {
        if (this.checked && emailInput.value) {
          localStorage.setItem("remembered_email", emailInput.value);
        } else {
          localStorage.removeItem("remembered_email");
        }
      });

      // Update saved email when user types
      emailInput.addEventListener("change", function () {
        if (rememberCheckbox.checked) {
          localStorage.setItem("remembered_email", this.value);
        }
      });
    }
  }

  /**
   * Setup Terms Checkbox
   */
  function setupTermsCheckbox() {
    const agreeCheckbox = document.getElementById("agreeTerms");
    const submitBtn = document.querySelector(".btn-auth");

    if (agreeCheckbox && submitBtn) {
      // Disable button initially
      if (submitBtn.type === "submit") {
        submitBtn.disabled = !agreeCheckbox.checked;

        agreeCheckbox.addEventListener("change", function () {
          submitBtn.disabled = !this.checked;
        });
      }
    }
  }

  /**
   * Setup Email Validation
   */
  function setupEmailValidation() {
    const emailInputs = document.querySelectorAll('input[type="email"]');

    emailInputs.forEach((input) => {
      input.addEventListener("blur", function () {
        if (this.value && !isValidEmail(this.value)) {
          this.classList.add("is-invalid");
        } else {
          this.classList.remove("is-invalid");
        }
      });
    });
  }

  /**
   * Validate email format
   */
  function isValidEmail(email) {
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return emailRegex.test(email);
  }

  /**
   * Show notification
   */
  function showNotification(message, type = "info") {
    const notification = document.createElement("div");
    notification.className = `alert alert-${type} alert-dismissible fade show`;
    notification.role = "alert";
    notification.style.cssText = `
      position: fixed;
      top: 20px;
      right: 20px;
      z-index: 9999;
      max-width: 450px;
      animation: slideInRight 0.3s ease-out;
      box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
    `;

    const iconMap = {
      success: "fa-check-circle",
      danger: "fa-exclamation-circle",
      warning: "fa-exclamation-triangle",
      info: "fa-info-circle",
    };

    const icon = iconMap[type] || "fa-info-circle";

    notification.innerHTML = `
      <i class="fas ${icon} me-2"></i>
      <span>${message}</span>
      <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    `;

    document.body.appendChild(notification);

    // Auto dismiss
    setTimeout(() => {
      notification.classList.remove("show");
      setTimeout(() => {
        notification.remove();
      }, 300);
    }, 5000);
  }

  /**
   * Setup Profile Avatar Edit
   */
  function setupAvatarEdit() {
    const avatarEditBtn = document.querySelector(".avatar-edit-btn");

    if (avatarEditBtn) {
      avatarEditBtn.addEventListener("click", function (e) {
        e.preventDefault();
        showNotification(
          "Tính năng thay đổi ảnh đại diện sẽ sớm được cập nhật",
          "info",
        );
      });
    }
  }

  /**
   * Initialize on DOM ready
   */
  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", function () {
      initAccountHandlers();
      setupRememberMe();
      setupTermsCheckbox();
      setupEmailValidation();
      setupAvatarEdit();
    });
  } else {
    initAccountHandlers();
    setupRememberMe();
    setupTermsCheckbox();
    setupEmailValidation();
    setupAvatarEdit();
  }

  // Add CSS animations if not already defined
  if (!document.querySelector("style[data-account-animations]")) {
    const style = document.createElement("style");
    style.setAttribute("data-account-animations", "true");
    style.innerHTML = `
      @keyframes slideInRight {
        from {
          opacity: 0;
          transform: translateX(20px);
        }
        to {
          opacity: 1;
          transform: translateX(0);
        }
      }

      @keyframes fadeInUp {
        from {
          opacity: 0;
          transform: translateY(10px);
        }
        to {
          opacity: 1;
          transform: translateY(0);
        }
      }

      .form-control-auth.is-valid,
      .form-control-profile.is-valid {
        border-color: #28a745;
        background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 8 8'%3e%3cpath fill='%2328a745' d='M2.3 6.73L.6 4.53c-.4-1.04.46-1.4 1.1-.8l1.1 1.4 3.4-3.8c.6-.63 1.6-.27 1.2.7l-4 4.6c-.43.5-.8.4-1.1.1z'/%3e%3c/svg%3e");
        background-position: right calc(0.375em + 0.1875rem) center;
        background-repeat: no-repeat;
        background-size: calc(0.75em + 0.375rem) calc(0.75em + 0.375rem);
        padding-right: calc(1.5em + 0.75rem);
      }

      .form-control-auth.is-invalid,
      .form-control-profile.is-invalid {
        border-color: #dc3545;
        background-image: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' width='12' height='12' fill='none' stroke='%23dc3545' viewBox='0 0 12 12'%3e%3ccircle cx='6' cy='6' r='4.5'/%3e%3cpath stroke-linejoin='round' d='M5.8 3.6h.4L6 6.5z'/%3e%3ccircle cx='6' cy='8.2' r='.6' fill='%23dc3545' stroke='none'/%3e%3c/svg%3e");
        background-position: right calc(0.375em + 0.1875rem) center;
        background-repeat: no-repeat;
        background-size: calc(0.75em + 0.375rem) calc(0.75em + 0.375rem);
        padding-right: calc(1.5em + 0.75rem);
      }

      .in-view {
        animation: fadeInUp 0.6s ease-out;
      }
    `;
    document.head.appendChild(style);
  }
})();
