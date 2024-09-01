namespace Trockeo
{
    public partial class Form1 : Form
    {
        private Panel pnlContent; // Panneau pour le contenu (connexion, inscription et réinitialisation du mot de passe)
        private Panel pnlLogin;
        private Panel pnlRegister;
        private Panel pnlForgotPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtRegisterUsername;
        private TextBox txtRegisterPassword;
        private TextBox txtRegisterConfirmPassword;
        private TextBox txtForgotEmail;
        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents1()
        {
            //// Configurer la fenêtre principale
            this.Text = "Trockeo Login";
            this.Size = new Size(400, 500);
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(0, 163, 224);

            // Ajouter une barre de titre personnalisée
            Panel titleBar = new Panel();
            titleBar.BackColor = Color.FromArgb(0, 163, 224);
            titleBar.Dock = DockStyle.Top;
            titleBar.Height = 40;
            titleBar.Padding = new Padding(10, 5, 10, 5);
            titleBar.Controls.Add(new Label
            {
                Text = "Trockeo Login",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            });

            // Boutons de contrôle
            Panel titleBarControls = new Panel();
            titleBarControls.Dock = DockStyle.Right;
            titleBarControls.Width = 60;
            titleBar.Controls.Add(titleBarControls);

            Button btnMinimize = new Button();
            btnMinimize.BackColor = Color.FromArgb(255, 189, 68);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Size = new Size(15, 15);
            btnMinimize.Location = new Point(0, 10);
            //btnMinimize.Click += BtnMinimize_Click;
            titleBarControls.Controls.Add(btnMinimize);

            Button btnMaximize = new Button();
            btnMaximize.BackColor = Color.FromArgb(0, 202, 78);
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.Size = new Size(15, 15);
            btnMaximize.Location = new Point(20, 10);
            //btnMaximize.Click += BtnMaximize_Click;
            titleBarControls.Controls.Add(btnMaximize);

            Button btnClose = new Button();
            btnClose.BackColor = Color.FromArgb(255, 96, 92);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(15, 15);
            btnClose.Location = new Point(40, 10);
            //btnClose.Click += BtnClose_Click;
            titleBarControls.Controls.Add(btnClose);

            this.Controls.Add(titleBar);

            // Logo
            PictureBox logo = new PictureBox();
            logo.ImageLocation = "C:\\Users\\randr\\Documents\\M2\\TPT\\Trockeo\\Resources\\logo_trockeo.png";
            logo.SizeMode = PictureBoxSizeMode.AutoSize;
            logo.Size = new Size(120, 80);
            logo.Location = new Point(120, 60);
            this.Controls.Add(logo);

            // Champ pour le nom d'utilisateur
            Label lblUsername = new Label();
            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(20, 160);
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10);
            this.Controls.Add(lblUsername);

            TextBox txtUsername = new TextBox();
            txtUsername.Location = new Point(20, 185);
            txtUsername.Size = new Size(300, 30);
            this.Controls.Add(txtUsername);

            // Champ pour le mot de passe
            Label lblPassword = new Label();
            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(20, 220);
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10);
            this.Controls.Add(lblPassword);

            TextBox txtPassword = new TextBox();
            txtPassword.Location = new Point(20, 245);
            txtPassword.Size = new Size(300, 30);
            txtPassword.PasswordChar = '*';
            this.Controls.Add(txtPassword);

            // Bouton de connexion
            Button btnLogin = new Button();
            btnLogin.Text = "Log In";
            btnLogin.Location = new Point(20, 290);
            btnLogin.Size = new Size(300, 35);
            btnLogin.BackColor = Color.FromArgb(123, 42, 183);
            btnLogin.ForeColor = Color.White;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += (sender, e) => BtnLogin_Click(sender, e, txtUsername.Text, txtPassword.Text);
            this.Controls.Add(btnLogin);

            // Bouton d'inscription
            Button btnRegister = new Button();
            btnRegister.Text = "Sign Up";
            btnRegister.Location = new Point(20, 340);
            btnRegister.Size = new Size(300, 35);
            btnRegister.BackColor = Color.FromArgb(0, 163, 224);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Click += BtnRegister_Click;
            this.Controls.Add(btnRegister);

            // Lien "Mot de passe oublié"
            LinkLabel lnkForgotPassword = new LinkLabel();
            lnkForgotPassword.Text = "Forgot password?";
            lnkForgotPassword.Location = new Point(115, 390);
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 10);
            lnkForgotPassword.LinkColor = Color.FromArgb(0, 163, 224);
            //lnkForgotPassword.Click += LnkForgotPassword_Click;
            this.Controls.Add(lnkForgotPassword);

            pnlForgotPassword = new Panel
            {
                Size = new Size(300, 200),
                Location = new Point(10, 10),
                BackColor = Color.FromArgb(240, 240, 240),
                Visible = false // Le panneau est caché par défaut
            };

            // Label et champ pour l'e-mail
            Label lblForgotEmail = new Label
            {
                Text = "Email:",
                Location = new Point(20, 30),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlForgotPassword.Controls.Add(lblForgotEmail);

            txtForgotEmail = new TextBox
            {
                Location = new Point(20, 55),
                Size = new Size(260, 30)
            };
            pnlForgotPassword.Controls.Add(txtForgotEmail);

            // Bouton pour envoyer le lien de réinitialisation
            Button btnSendResetLink = new Button
            {
                Text = "Send Reset Link",
                Location = new Point(20, 95),
                Size = new Size(260, 35),
                BackColor = Color.FromArgb(123, 42, 183),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSendResetLink.Click += BtnSendResetLink_Click;
            pnlForgotPassword.Controls.Add(btnSendResetLink);

            // Ajouter le panneau au formulaire
            this.Controls.Add(pnlForgotPassword);
        }

        private void InitializeCustomComponents() {
            this.Text = "Trockeo Login";
            this.Size = new Size(350, 450);
            this.Dock = DockStyle.Fill;
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Créer la barre de titre
            Panel titleBar = new Panel
            {
                Size = new Size(330, 30),
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(0, 163, 224),
                ForeColor = Color.White
            };
            Label titleLabel = new Label
            {
                Text = "Trockeo Login",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(10, 5),
                AutoSize = true
            };
            titleBar.Controls.Add(titleLabel);

            Panel titleBarControls = new Panel();
            titleBarControls.Dock = DockStyle.Right;
            titleBarControls.Width = 60;
            titleBar.Controls.Add(titleBarControls);

            Button btnMinimize = new Button();
            btnMinimize.BackColor = Color.FromArgb(255, 189, 68);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.Size = new Size(15, 15);
            btnMinimize.Location = new Point(0, 10);
            //btnMinimize.Click += BtnMinimize_Click;
            titleBarControls.Controls.Add(btnMinimize);

            Button btnMaximize = new Button();
            btnMaximize.BackColor = Color.FromArgb(0, 202, 78);
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.Size = new Size(15, 15);
            btnMaximize.Location = new Point(20, 10);
            //btnMaximize.Click += BtnMaximize_Click;
            titleBarControls.Controls.Add(btnMaximize);

            Button btnClose = new Button();
            btnClose.BackColor = Color.FromArgb(255, 96, 92);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Size = new Size(15, 15);
            btnClose.Location = new Point(40, 10);
            //btnClose.Click += BtnClose_Click;
            titleBarControls.Controls.Add(btnClose);
            this.Controls.Add(titleBar);

            // Créer le panneau du logo
            Panel logoPanel = new Panel
            {
                Size = new Size(330, 80),
                Location = new Point(0, 30),
                BackColor = Color.White
            };
            PictureBox logo = new PictureBox
            {
                ImageLocation = "C:\\Users\\randr\\Documents\\M2\\TPT\\Trockeo\\Resources\\logo_trockeo.png",
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(120, 80),
                Location = new Point(105, 10)
            };
            logoPanel.Controls.Add(logo);
            this.Controls.Add(logoPanel);

            // Créer le panneau de contenu
            pnlContent = new Panel
            {
                Size = new Size(360, 450),
                Location = new Point(0, 110),
                //BackColor = Color.FromArgb(240, 240, 240)
            };
            this.Controls.Add(pnlContent);

            // Créer le panneau de connexion
            pnlLogin = new Panel
            {
                Size = new Size(360, 450),
                Location = new Point(15, 10),
                //BackColor = Color.FromArgb(240, 240, 240)
                BackColor = Color.White
            };

            // Label pour le nom d'utilisateur
            Label lblUsername = new Label
            {
                Text = "Nom d'utilisateur:",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlLogin.Controls.Add(lblUsername);

            // Champ pour le nom d'utilisateur
            txtUsername = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(260, 30)
            };
            pnlLogin.Controls.Add(txtUsername);

            // Label pour le mot de passe
            Label lblPassword = new Label
            {
                Text = "Mot de passe:",
                Location = new Point(20, 90),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlLogin.Controls.Add(lblPassword);

            // Champ pour le mot de passe
            txtPassword = new TextBox
            {
                Location = new Point(20, 120),
                Size = new Size(260, 30),
                PasswordChar = '*'
            };
            pnlLogin.Controls.Add(txtPassword);

            // Bouton de connexion
            Button btnLogin = new Button
            {
                Text = "Connexion",
                Location = new Point(20, 160),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(123, 42, 183),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnLogin.Click += (sender, e) => BtnLogin_Click(sender, e, txtUsername.Text, txtPassword.Text);
            pnlLogin.Controls.Add(btnLogin);

            // Bouton d'inscription
            Button btnRegister = new Button
            {
                Text = "Inscription",
                Location = new Point(160, 160),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(123, 42, 183),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRegister.Click += BtnRegister_Click;
            pnlLogin.Controls.Add(btnRegister);

            //// Bouton mot de passe oublié
            //Button btnForgotPassword = new Button
            //{
            //    Text = "Mot de passe oublié",
            //    Location = new Point(20, 200),
            //    Size = new Size(260, 35),
            //    BackColor = Color.FromArgb(123, 42, 183),
            //    ForeColor = Color.White,
            //    FlatStyle = FlatStyle.Flat
            //};
            //btnForgotPassword.Click += BtnForgotPassword_Click;
            //pnlLogin.Controls.Add(btnForgotPassword);

            // Lien "Mot de passe oublié"
            LinkLabel lnkForgotPassword = new LinkLabel();
            lnkForgotPassword.Text = "Mot de passe oublié ?";
            //lnkForgotPassword.BackColor = Color.Black ;
            lnkForgotPassword.Location = new Point(115, 200);
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 10);
            lnkForgotPassword.LinkColor = Color.FromArgb(0, 163, 224);
            lnkForgotPassword.Click += LnkForgotPassword_Click;
            pnlLogin.Controls.Add(lnkForgotPassword);

            // Ajouter le panneau de connexion au panneau de contenu
            pnlContent.Controls.Add(pnlLogin);

            // Créer le panneau d'inscription
            pnlRegister = new Panel
            {
                Size = new Size(360, 450),
                Location = new Point(15, 10),
                //BackColor = Color.FromArgb(240, 240, 240),
                Visible = false // Cacher le panneau par défaut
            };

            // Label pour le nom d'utilisateur
            Label lblRegisterUsername = new Label
            {
                Text = "Nom d'utilisateur:",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlRegister.Controls.Add(lblRegisterUsername);

            // Champ pour le nom d'utilisateur
            txtRegisterUsername = new TextBox
            {
                Location = new Point(20, 50),
                Size = new Size(260, 30)
            };
            pnlRegister.Controls.Add(txtRegisterUsername);

            // Label pour le mot de passe
            Label lblRegisterPassword = new Label
            {
                Text = "Mot de passe:",
                Location = new Point(20, 90),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlRegister.Controls.Add(lblRegisterPassword);

            // Champ pour le mot de passe
            txtRegisterPassword = new TextBox
            {
                Location = new Point(20, 120),
                Size = new Size(260, 30),
                PasswordChar = '*'
            };
            pnlRegister.Controls.Add(txtRegisterPassword);

            // Label pour confirmer le mot de passe
            Label lblRegisterConfirmPassword = new Label
            {
                Text = "Confirmer le mot de passe:",
                Location = new Point(20, 160),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlRegister.Controls.Add(lblRegisterConfirmPassword);

            // Champ pour confirmer le mot de passe
            txtRegisterConfirmPassword = new TextBox
            {
                Location = new Point(20, 190),
                Size = new Size(260, 30),
                PasswordChar = '*'
            };
            pnlRegister.Controls.Add(txtRegisterConfirmPassword);

            // Bouton d'inscription
            Button btnRegisterSubmit = new Button
            {
                Text = "S'inscrire",
                Location = new Point(20, 230),
                Size = new Size(260, 35),
                BackColor = Color.FromArgb(123, 42, 183),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRegisterSubmit.Click += BtnRegisterSubmit_Click;
            pnlRegister.Controls.Add(btnRegisterSubmit);

            // Ajouter le panneau d'inscription au panneau de contenu
            pnlContent.Controls.Add(pnlRegister);

           

            // Créer le panneau de réinitialisation du mot de passe
            pnlForgotPassword = new Panel
            {
                Size = new Size(360, 450),
                Location = new Point(15, 10),
                BackColor = Color.FromArgb(240, 240, 240),
                Visible = false // Le panneau est caché par défaut
            };

            // Label et champ pour l'e-mail
            Label lblForgotEmail = new Label
            {
                Text = "Email:",
                Location = new Point(20, 30),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };
            pnlForgotPassword.Controls.Add(lblForgotEmail);

            txtForgotEmail = new TextBox
            {
                Location = new Point(20, 55),
                Size = new Size(260, 30)
            };
            pnlForgotPassword.Controls.Add(txtForgotEmail);

            // Bouton pour envoyer le lien de réinitialisation
            Button btnSendResetLink = new Button
            {
                Text = "Envoyer le lien de réinitialisation",
                Location = new Point(20, 95),
                Size = new Size(260, 35),
                BackColor = Color.FromArgb(123, 42, 183),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSendResetLink.Click += BtnSendResetLink_Click;
            pnlForgotPassword.Controls.Add(btnSendResetLink);

            // Ajouter le panneau de réinitialisation du mot de passe au panneau de contenu
            pnlContent.Controls.Add(pnlForgotPassword);
        }

        private void BtnLogin_Click(object sender, EventArgs e, string username, string password)
        {
            ProductListForm productListForm = new ProductListForm();
            productListForm.Show();

            // Optionnel : Fermer le formulaire de connexion
            this.Hide();
            // Gestion de la connexion
            MessageBox.Show($"Tentative de connexion pour {username} avec le mot de passe {password}");
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Afficher le panneau d'inscription
            pnlLogin.Visible = false;
            pnlRegister.Visible = true;
            pnlForgotPassword.Visible = false;
        }

        private void BtnRegisterSubmit_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;
            string confirmPassword = txtRegisterConfirmPassword.Text;

            if (username == "" || password == "" || confirmPassword == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return;
            }

            // Ajouter la logique d'inscription ici
            MessageBox.Show($"Inscription réussie pour {username}.");
        }

        //private void BtnForgotPassword_Click(object sender, EventArgs e)
        //{
        //    // Afficher le panneau de réinitialisation du mot de passe
        //    pnlLogin.Visible = false;
        //    pnlRegister.Visible = false;
        //    pnlForgotPassword.Visible = true;
        //}

        private void LnkForgotPassword_Click(object sender, EventArgs e)
        {
            // Afficher le panneau de réinitialisation du mot de passe
            pnlLogin.Visible = false;
            pnlRegister.Visible = false;
            pnlForgotPassword.Visible = true;
        }

        private void BtnSendResetLink_Click(object sender, EventArgs e)
        {
            string email = txtForgotEmail.Text;

            if (email == "")
            {
                MessageBox.Show("Veuillez entrer votre e-mail.");
                return;
            }

            // Ajouter la logique de réinitialisation du mot de passe ici
            MessageBox.Show("Un lien de réinitialisation a été envoyé à votre e-mail.");
        }
    }
    
}
