using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Trockeo.Models; // Assurez-vous que le namespace est correct

namespace Trockeo
{
    public partial class ProductListForm : Form
    {
        private readonly string apiUrl = "https://mbdsp10-trockeo-back.onrender.com/api/products";
        public ProductListForm()
        {
            InitializeComponent();
            InitializeCustomComponent();
            LoadProducts();
        }

        private void InitializeCustomComponent()
        {

            // Configuration de la fenêtre principale
            this.Text = "Trockeo - Échanges et Objets";
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.Size = new Size(1000, 700);

            this.panelContainer = new System.Windows.Forms.Panel();
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.windowHeaderPanel = new System.Windows.Forms.Panel();
            this.windowTitleLabel = new System.Windows.Forms.Label();
            this.windowControlsPanel = new System.Windows.Forms.Panel();
            this.windowCloseButton = new System.Windows.Forms.Button();
            this.windowMinimizeButton = new System.Windows.Forms.Button();
            this.windowMaximizeButton = new System.Windows.Forms.Button();
            this.productsButton = new System.Windows.Forms.Button();
            this.productsListButton = new System.Windows.Forms.Button();
            this.windowContentPanel = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.userActionsPanel = new System.Windows.Forms.Panel();
            this.panelProductDetails = new System.Windows.Forms.Panel();
            this.mainWindowPanel = new System.Windows.Forms.Panel();
            this.sideBarPanel = new System.Windows.Forms.Panel();
            this.loginLink = new System.Windows.Forms.LinkLabel();
            this.signUpLink = new System.Windows.Forms.LinkLabel();
            this.productGridPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addProductModal = new System.Windows.Forms.Form();
            this.myExchangesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelContainer.SuspendLayout();
            this.windowHeaderPanel.SuspendLayout();
            this.windowControlsPanel.SuspendLayout();
            this.windowContentPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.userActionsPanel.SuspendLayout();
            this.addProductModal.SuspendLayout();
            this.panelProductDetails.SuspendLayout();
            this.myExchangesPanel.SuspendLayout();
            this.mainWindowPanel.SuspendLayout();
            this.sideBarPanel.SuspendLayout();
            this.SuspendLayout();

            // Ajouter un panel pour la fenêtre (conteneur principal)
            mainWindowPanel.BackColor = Color.White;
            mainWindowPanel.Size = new Size(800, 600);
            mainWindowPanel.Location = new Point(100, 50);
            mainWindowPanel.BorderStyle = BorderStyle.FixedSingle;
            mainWindowPanel.Dock=DockStyle.Fill;
            //mainWindowPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(mainWindowPanel);

            this.windowHeaderPanel = new System.Windows.Forms.Panel();
            this.windowHeaderPanel.SuspendLayout();
            this.windowHeaderPanel.BackColor = Color.FromArgb(0, 160, 255);
            this.windowHeaderPanel.Dock = DockStyle.Top;
            this.windowHeaderPanel.Padding = new System.Windows.Forms.Padding(10);
            this.windowHeaderPanel.Size = new System.Drawing.Size(758, 40);
            this.windowHeaderPanel.TabIndex = 0;
            this.Controls.Add(this.windowHeaderPanel);

            this.windowTitleLabel = new Label();
            this.windowTitleLabel.AutoSize = true;
            this.windowTitleLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.windowTitleLabel.ForeColor = Color.White;
            this.windowTitleLabel.Location = new System.Drawing.Point(10, 10);
            this.windowTitleLabel.Name = "windowTitleLabel";
            this.windowTitleLabel.Size = new System.Drawing.Size(132, 16);
            this.windowTitleLabel.TabIndex = 0;
            this.windowTitleLabel.Text = "Trockeo Products";
            this.windowHeaderPanel.Controls.Add(this.windowTitleLabel);

            // 
            // windowControlsPanel
            // 
            this.windowControlsPanel = new Panel();           
            this.windowControlsPanel.Dock =DockStyle.Right;
            this.windowControlsPanel.Size = new Size(100, 24);
            this.windowControlsPanel.TabIndex = 1;
            this.windowControlsPanel.SuspendLayout();
            this.windowHeaderPanel.Controls.Add(this.windowControlsPanel);

            // 
            // windowCloseButton
            // 
            this.windowCloseButton = new System.Windows.Forms.Button();
            this.windowCloseButton.BackColor = Color.FromArgb(255, 95, 86);
            this.windowCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowCloseButton.FlatAppearance.BorderSize = 0;
            this.windowCloseButton.Location = new System.Drawing.Point(72, 3);
            this.windowCloseButton.Size = new System.Drawing.Size(20, 20);
            this.windowCloseButton.TabIndex = 2;
            this.windowCloseButton.UseVisualStyleBackColor = false;
            this.windowCloseButton.Click += new System.EventHandler(this.WindowCloseButton_Click);
            this.windowControlsPanel.Controls.Add(this.windowCloseButton);
            // 
            // windowMinimizeButton
            // 
            this.windowMinimizeButton = new System.Windows.Forms.Button();
            this.windowMinimizeButton.BackColor = Color.FromArgb(255, 189, 46);
            this.windowMinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowMinimizeButton.FlatAppearance.BorderSize = 0;
            this.windowMinimizeButton.Location = new System.Drawing.Point(22, 3);
            this.windowMinimizeButton.Size = new System.Drawing.Size(20, 20);
            this.windowMinimizeButton.TabIndex = 0;
            this.windowMinimizeButton.UseVisualStyleBackColor = false;
            this.windowMinimizeButton.Click += new System.EventHandler(this.WindowMinimizeButton_Click);
            this.windowControlsPanel.Controls.Add(this.windowMinimizeButton);

            // 
            // windowMaximizeButton
            // 
            this.windowMaximizeButton = new System.Windows.Forms.Button();
            this.windowMaximizeButton.BackColor = Color.FromArgb(39, 201, 63);
            this.windowMaximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.windowMaximizeButton.FlatAppearance.BorderSize = 0;
            this.windowMaximizeButton.Location = new System.Drawing.Point(47, 3);
            this.windowMaximizeButton.Size = new System.Drawing.Size(20, 20);
            this.windowMaximizeButton.TabIndex = 1;
            this.windowMaximizeButton.UseVisualStyleBackColor = false;
            this.windowMaximizeButton.Click += new System.EventHandler(this.WindowMaximizeButton_Click);
            this.windowControlsPanel.Controls.Add(this.windowMaximizeButton);

            this.headerPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Size = new System.Drawing.Size(738, 100);
            this.headerPanel.TabIndex = 0;
            mainWindowPanel.Controls.Add(this.headerPanel);


            // Ajouter la barre de recherche dans mainContentPanel
            this.searchBarPanel = new System.Windows.Forms.Panel();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();

            // ...
            // searchBarPanel
            // Ajouter la barre de recherche dans searchBarPanel
            this.searchBarPanel = new Panel();
            this.searchTextBox = new TextBox();
            this.searchButton = new Button();

            this.searchBarPanel.Dock = DockStyle.Top;
            this.searchBarPanel.Height = 40; // Hauteur du panneau de recherche

            // Configurer la TextBox
            this.searchTextBox.Size = new Size(400, 20);
            this.searchTextBox.Location = new Point(20, 10); // Position dans le panneau
            this.searchTextBox.PlaceholderText = "Rechercher un objet...";
            this.searchButton.Text = this.searchTextBox.Width.ToString();
            this.searchBarPanel.Controls.Add(this.searchTextBox);

            // Configurer le Button
            this.searchButton.Size = new Size(100, 35);
            this.searchButton.Location = new Point(this.searchTextBox.Width + 20, 0); 
            this.searchButton.Text = "Rechercher";
            this.searchButton.BackColor = System.Drawing.Color.FromArgb(0, 160, 233);
            this.searchButton.ForeColor = Color.White;
            this.searchButton.FlatStyle = FlatStyle.Flat;
            this.searchButton.FlatAppearance.BorderSize = 0;
            this.searchBarPanel.Controls.Add(this.searchButton);

            this.headerPanel.Controls.Add(this.searchBarPanel);



            this.userActionsPanel = new System.Windows.Forms.Panel();
            this.loginLink = new System.Windows.Forms.LinkLabel();
            this.signUpLink = new System.Windows.Forms.LinkLabel();
            // 
            // userActionsPanel
            // 
            this.userActionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.userActionsPanel.Size = new System.Drawing.Size(200, 50);
            this.userActionsPanel.TabIndex = 2;
            this.headerPanel.Controls.Add(this.userActionsPanel);
            // 
            // loginLink
            // 
            this.loginLink.AutoSize = true;
            this.loginLink.LinkColor = Color.FromArgb(0, 160, 255);
            this.loginLink.Location = new System.Drawing.Point(10, 15);
            this.loginLink.Size = new System.Drawing.Size(40, 13);
            this.loginLink.TabIndex = 0;
            this.loginLink.TabStop = true;
            this.loginLink.Text = "Login";
            this.userActionsPanel.Controls.Add(this.loginLink);

            // 
            // signUpLink
            // 
            this.signUpLink.AutoSize = true;
            this.signUpLink.LinkColor = Color.FromArgb(0, 160, 255);
            this.signUpLink.Location = new System.Drawing.Point(60, 15);
            this.signUpLink.Size = new System.Drawing.Size(55, 13);
            this.signUpLink.TabIndex = 1;
            this.signUpLink.TabStop = true;
            this.signUpLink.Text = "Sign Up";
            this.userActionsPanel.Controls.Add(this.signUpLink);
            //this.headerPanel.Controls.Add(this.userActionsPanel);

            this.productGridPanel.AutoScroll = true;
            this.productGridPanel.Dock = DockStyle.Fill;
            this.productGridPanel.FlowDirection = FlowDirection.LeftToRight;
            this.productGridPanel.WrapContents = true;
            this.productGridPanel.Padding = new Padding(10);
            this.productGridPanel.Size = new System.Drawing.Size(738, 482);
            this.productGridPanel.TabIndex = 1;
            mainWindowPanel.Controls.Add(this.productGridPanel);

            this.myExchangesPanel.AutoScroll = true;
            this.myExchangesPanel.Size = new System.Drawing.Size(738, 482);
            this.myExchangesPanel.Location = new Point(220, 50);  // Positionner manuellement
            this.myExchangesPanel.FlowDirection = FlowDirection.LeftToRight;
            this.myExchangesPanel.WrapContents = true;
            this.myExchangesPanel.Margin = new Padding(100);
            this.myExchangesPanel.Padding = new Padding(10);
            mainWindowPanel.Controls.Add(this.myExchangesPanel);



            // Add Product Modal
            this.addProductModal.Text = "Ajouter un nouvel objet";
            this.addProductModal.Size = new System.Drawing.Size(400, 300);
            this.addProductModal.StartPosition = FormStartPosition.CenterParent;
            this.addProductModal.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.addProductModal.MaximizeBox = false;
            this.addProductModal.MinimizeBox = false;

            InitializeAddProductModal();


            proposeExchangeModal = new Form
            {
                Size = new System.Drawing.Size(400, 300),
                BackColor = System.Drawing.Color.White,
                Visible = false
            };
            proposeExchangeModal.Controls.Add(new Label
            {
                Text = "Proposer un échange",
                Font = new System.Drawing.Font("Arial", 14, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(10, 10)
            });
            var desiredObjectLabel = new Label
            {
                Text = "Objet souhaité: [Titre de l'objet]",
                Location = new System.Drawing.Point(10, 50),
                Width = 300
            };
            var userObjectComboBox = new ComboBox
            {
                Location = new System.Drawing.Point(10, 90),
                Width = 300
            };
            userObjectComboBox.Items.AddRange(new string[] { "Livre de science-fiction", "Vélo de montagne", "Appareil photo numérique" });

            var exchangeMessageTextBox = new TextBox
            {
                PlaceholderText = "Message (optionnel)",
                Location = new System.Drawing.Point(10, 130),
                Width = 300
            };
            var proposeButton = new Button
            {
                Text = "Proposer l'échange",
                Location = new System.Drawing.Point(10, 170),
                BackColor = System.Drawing.Color.FromArgb(0, 160, 233),
                ForeColor = System.Drawing.Color.White
            };
            proposeButton.Click += (sender, e) =>
            {
                MessageBox.Show($"Échange proposé avec succès :\nObjet : {userObjectComboBox.SelectedItem}\nMessage : {exchangeMessageTextBox.Text}");
                proposeExchangeModal.Visible = false;
            };
            proposeExchangeModal.Controls.Add(desiredObjectLabel);
            proposeExchangeModal.Controls.Add(userObjectComboBox);
            proposeExchangeModal.Controls.Add(exchangeMessageTextBox);
            proposeExchangeModal.Controls.Add(proposeButton);
 

            // Ajouter un panel pour la barre latérale
            sidebarPanel.BackColor = Color.FromArgb(0, 144, 209); // Couleur bleu clair
            sidebarPanel.Width = 200;
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Padding = new Padding(0, 0, 0, 0);
            mainWindowPanel.Controls.Add(sidebarPanel);

            Button addProductButton = new Button();
            addProductButton.Text = "Ajouter un objet";
            addProductButton.Dock = DockStyle.Top;
            addProductButton.Height = 50;
            addProductButton.FlatStyle = FlatStyle.Flat;
            addProductButton.ForeColor = Color.White;
            addProductButton.FlatAppearance.BorderSize = 0;
            sidebarPanel.Controls.Add(addProductButton);

            Button messagesButton = new Button();
            messagesButton.Text = "Messages";
            messagesButton.Dock = DockStyle.Top;
            messagesButton.Height = 50;
            messagesButton.FlatStyle = FlatStyle.Flat;
            messagesButton.ForeColor = Color.White;
            messagesButton.FlatAppearance.BorderSize = 0;
            sidebarPanel.Controls.Add(messagesButton);


            Button myObjectsButton = new Button();
            myObjectsButton.Text = "Mes objets";
            myObjectsButton.Dock = DockStyle.Top;
            myObjectsButton.Height = 50;
            myObjectsButton.FlatStyle = FlatStyle.Flat;
            myObjectsButton.ForeColor = Color.White;
            myObjectsButton.FlatAppearance.BorderSize = 0;
            sidebarPanel.Controls.Add(myObjectsButton);


            Button myExchangesButton = new Button();
            myExchangesButton.Text = "Mes échanges";
            myExchangesButton.Dock = DockStyle.Top;
            myExchangesButton.Height = 50;
            myExchangesButton.FlatStyle = FlatStyle.Flat;
            myExchangesButton.ForeColor = Color.White;
            myExchangesButton.FlatAppearance.BorderSize = 0;
            sidebarPanel.Controls.Add(myExchangesButton);

            // Ajouter les éléments du menu dans la barre latérale
            productsButton.Text = "Produits à échanger";
            productsButton.Dock = DockStyle.Top;
            productsButton.Height = 50;
            productsButton.FlatStyle = FlatStyle.Flat;
            productsButton.ForeColor = Color.White;
            productsButton.FlatAppearance.BorderSize = 0;
            sidebarPanel.Controls.Add(productsButton);

            // Ajouter les éléments du menu dans la barre latérale
            productsListButton.Text = "Retour aux échanges";
            productsListButton.Dock = DockStyle.Top;
            productsListButton.Height = 50;
            productsListButton.FlatStyle = FlatStyle.Flat;
            productsListButton.ForeColor = Color.White;
            productsListButton.FlatAppearance.BorderSize = 0;
            productsListButton.Visible = false;
            sidebarPanel.Controls.Add(productsListButton);

            mainWindowPanel.Controls.Add(myExchangesPanel);


            // Ajouter le logo
            PictureBox logoPictureBox = new PictureBox();
            logoPictureBox.Image = Image.FromFile("C:\\Users\\randr\\Documents\\M2\\TPT\\Trockeo\\Resources\\trockeo.png");  // Assurez-vous de mettre le chemin correct de votre logo
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.Height = 80;
            logoPictureBox.Dock = DockStyle.Top;
            sidebarPanel.Controls.Add(logoPictureBox);

            // Ajouter le nom de l'application
            Label appNameLabel = new Label();
            appNameLabel.Text = "Trockeo";
            appNameLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            appNameLabel.ForeColor = Color.White;
            appNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            appNameLabel.Dock = DockStyle.Top;
            sidebarPanel.Controls.Add(appNameLabel);

            addProductButton.Click += (sender, e) =>
            {
                // Afficher le panel modal
                this.addProductModal.Visible = true;
            };

            proposeButton.Click += (sender, e) =>
            {
                MessageBox.Show($"Échange proposé avec succès :\nObjet : {userObjectComboBox.SelectedItem}\nMessage : {exchangeMessageTextBox.Text}");
                proposeExchangeModal.Visible = false;  // Masquer le modal après l'échange
            };


            

            
            myExchangesButton.Click += (sender, e) =>
            {
                ShowMyExchanges();
            };

            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product List";
            this.panelContainer.ResumeLayout(false);
            this.windowHeaderPanel.ResumeLayout(false);
            this.windowHeaderPanel.PerformLayout();
            this.windowControlsPanel.ResumeLayout(false);
            this.windowContentPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.userActionsPanel.ResumeLayout(false);
            this.userActionsPanel.PerformLayout();
            this.addProductModal.ResumeLayout(false);
            this.addProductModal.PerformLayout();
            this.panelProductDetails.ResumeLayout(false);
            this.panelProductDetails.PerformLayout();
            this.myExchangesPanel.ResumeLayout(false);
            this.myExchangesPanel.PerformLayout();
            this.mainWindowPanel.ResumeLayout(false);
            this.mainWindowPanel.PerformLayout();
            this.sidebarPanel.ResumeLayout(false);
            this.sideBarPanel.PerformLayout();
            this.ResumeLayout(false);

            

        }

        private void InitializeAddProductModal()
        {
            Label lblTitle = new Label { Text = "Titre de l'objet:", Top = 20, Left = 20, Width = 100 };
            TextBox txtTitle = new TextBox { Top = 20, Left = 130, Width = 200 };
            Label lblDescription = new Label { Text = "Description de l'objet:", Top = 60, Left = 20, Width = 100 };
            TextBox txtDescription = new TextBox { Top = 60, Left = 130, Width = 200, Multiline = true, Height = 80 };
            Label lblDesiredExchange = new Label { Text = "Objet souhaité en échange:", Top = 150, Left = 20, Width = 150 };
            TextBox txtDesiredExchange = new TextBox { Top = 150, Left = 180, Width = 150 };
            Button btnAdd = new Button { Text = "Ajouter", Top = 200, Left = 230, Width = 100, BackColor = System.Drawing.Color.FromArgb(0, 160, 233), ForeColor = System.Drawing.Color.White };

            this.addProductModal.Controls.Add(lblTitle);
            this.addProductModal.Controls.Add(txtTitle);
            this.addProductModal.Controls.Add(lblDescription);
            this.addProductModal.Controls.Add(txtDescription);
            this.addProductModal.Controls.Add(lblDesiredExchange);
            this.addProductModal.Controls.Add(txtDesiredExchange);
            this.addProductModal.Controls.Add(btnAdd);
        }



        private void CloseModal_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SaveButton_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadProducts()
        {
            try
            {
                var products = await FetchProductsFromApiAsync();
                DisplayProducts(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des produits: {ex.Message}");
            }
        }

        private async Task<List<Product>> FetchProductsFromApiAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(apiUrl);
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);

                var products = new List<Product>();
                foreach (var item in apiResponse.Data.Content)
                {
                    //foreach (var picture in item.Pictures)
                    //{
                        products.Add(new Product
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Description = item.Description,
                            Category = item.Category,
                            State = item.State,
                            EnteredDate = item.EnteredDate,
                            //ImageUrl = picture.Path // Assumons que Path est le chemin de l'image
                        });
                    //}
                }

                return products;
            }
        }

        private void DisplayProducts(List<Product> products)
        {
            // Nettoyer les anciens produits
            this.productGridPanel.Controls.Clear();

            foreach (var product in products)
            {
                var productCard = new Panel
                {
                    Size = new Size(200, 350), // Ajuster la taille pour correspondre à la maquette
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10),
                    Padding = new Padding(10)
                };

                var productImage = new PictureBox
                {
                    Size = new Size(200, 150),
                    //ImageLocation = "C:\\Users\\randr\\Documents\\M2\\TPT\\Trockeo\\Resources\\pexels-fotios-photos-1092644.jpg",
                    ImageLocation = "https://picsum.photos/100/100",
                    SizeMode = PictureBoxSizeMode.StretchImage
                };

                var productInfo = new Label
                {
                    Text = $"{product.Name}",
                    Font = new Font("Arial", 10F, FontStyle.Regular),
                    ForeColor = Color.FromArgb(0, 160, 255),
                    AutoSize = true
                };

                var exchangeButton = new Button
                {
                    Text = "Proposer un échange",
                    BackColor = Color.FromArgb(0, 160, 255),
                    ForeColor = Color.White,
                    Dock = DockStyle.Bottom
                };

                productCard.Controls.Add(productImage);
                productCard.Controls.Add(productInfo);
                productCard.Controls.Add(exchangeButton);

                productInfo.Location = new Point(0, productImage.Height + 10);
                exchangeButton.Location = new Point(0, productCard.Height - exchangeButton.Height);
                exchangeButton.Click += (sender, e) =>
                {
                    // Afficher le panel modal
                    this.proposeExchangeModal.Visible = true;
                };

                productImage.Click += (sender, e) =>
                {
                    ShowProductDetails(product);
                    // Créez et affichez la fenêtre des détails du produit
                    //var detailForm = new ProductDetailForm(product); // Votre formulaire de détails de produit
                    //detailForm.ShowDialog(); // Affiche la fenêtre en modal
                };

                this.productGridPanel.Controls.Add(productCard);
            }
        }


            private void WindowCloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WindowMinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void WindowMaximizeButton_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        //private void InitializeProductDetailsPanel()
        //{
        //    panelProductDetails = new Panel
        //    {
        //        Size = new Size(800, 600),
        //        Location = new Point(200, 50),
        //        Visible = false // Masqué au départ
        //    };
        //    this.Controls.Add(panelProductDetails);

        //    // Vous pouvez ajouter des contrôles à ce panel pour afficher les détails du produit
        //}

        private void ShowProductDetails(Product product)
        {
            // Masquer la liste des produits (ou ajuster l'affichage)
            headerPanel.Visible = false;
            productGridPanel.Visible = false;
            productsButton.Hide();
            productsListButton.Show();

            sidebarPanel.Controls.Clear();
            // Remplir le panel avec les informations du produit
            panelProductDetails.Controls.Clear(); // Nettoyer les contrôles précédents

            // Exemple : Ajouter une étiquette pour le titre du produit
            PictureBox objectImage = new PictureBox
            {
                Image = Image.FromFile(product.Picture.Path), // Remplacez par l'image du produit
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(300, 200),
                Location = new Point(210, 50),
                BorderStyle = BorderStyle.FixedSingle
            };
            mainWindowPanel.Controls.Add(objectImage);

            Label objectTitle = new Label
            {
                Text = product.Name,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(200, 20),
                AutoSize = true
            };
            mainWindowPanel.Controls.Add(objectTitle);

            Label objectDescription = new Label
            {
                Text = product.Description,
                Font = new Font("Arial", 12, FontStyle.Regular),
                Location = new Point(210, 60),
                AutoSize = true
            };
            mainWindowPanel.Controls.Add(objectDescription);

            // Bouton "Proposer un échange"
            Button exchangeBtn = new Button
            {
                Text = "Proposer un échange",
                BackColor = Color.FromArgb(0, 160, 233),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(210, 300),
                Size = new Size(200, 40)
            };
            exchangeBtn.Click += (sender, e) =>
            {
                this.proposeExchangeModal.Visible = true;
            };
            mainWindowPanel.Controls.Add(exchangeBtn);

            // Section "À propos du propriétaire"
            Panel ownerInfo = new Panel
            {
                BackColor = Color.FromArgb(249, 249, 249),
                Size = new Size(400, 100),
                Location = new Point(210, 370),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };
            mainWindowPanel.Controls.Add(ownerInfo);

            Label ownerTitle = new Label
            {
                Text = "À propos du propriétaire",
                Font = new Font("Arial", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            ownerInfo.Controls.Add(ownerTitle);

            Label ownerDetails = new Label
            {
                Text = "John D. - Membre depuis 2022\n15 échanges réussis",
                Font = new Font("Arial", 10, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(10, 40)
            };
            ownerInfo.Controls.Add(ownerDetails);


            panelProductDetails.Visible = true; // Afficher le panel
        }

        private void ShowMyExchanges()
        {
            // Masquer la liste des produits (ou ajuster l'affichage)
            headerPanel.Visible = false;
            productGridPanel.Visible = false;
            myExchangesPanel.Visible = true;
            productsButton.Hide();
            productsListButton.Show();



            // Initialize with sample data
            var exchanges = new List<Exchange>
            {
                new Exchange
                {
                    Title = "Smartphone contre Appareil photo",
                    ImageUrl = "https://picsum.photos/100/100",
                    Status = "En attente",
                    Date = new DateTime(2023, 3, 15),
                    Description = "Vous avez proposé votre smartphone en échange d'un appareil photo reflex."
                },
                new Exchange
                {
                    Title = "Vélo contre Guitare électrique",
                    ImageUrl = "https://picsum.photos/100/100",
                    Status = "Accepté",
                    Date = new DateTime(2023, 3, 10),
                    Description = "Votre proposition d'échanger votre vélo contre une guitare électrique a été acceptée."
                },
                new Exchange
                {
                    Title = "Console de jeux contre Tablette graphique",
                    ImageUrl = "https://picsum.photos/100/100",
                    Status = "Refusé",
                    Date = new DateTime(2023, 3, 5),
                    Description = "Votre proposition d'échanger votre console de jeux contre une tablette graphique a été refusée."
                }
            };

          
            // Title Label
            Label lblTitle = new Label
            {
                Text = "Mes échanges",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Black,
                Location = new Point(220, 20),
                AutoSize = true
            };
           this.myExchangesPanel.Controls.Add(lblTitle);

            AddExchangesContent(exchanges);
            
        }

        private void AddExchangesContent(List<Exchange> exchanges)
        {
            //var exchangeList = new FlowLayoutPanel
            //{
            //    Location = new Point(250, 100),
            //    //Dock = DockStyle.Fill,
            //    AutoScroll = true,
            //    FlowDirection = FlowDirection.TopDown
            //};

            foreach (var exchange in exchanges)
            {
                var exchangeItem = new Panel
                {
                    Size = new Size(750, 120),
                    BackColor = Color.FromArgb(249, 249, 249),
                    Margin = new Padding(10),
                    BorderStyle = BorderStyle.FixedSingle,
                    Padding = new Padding(10)
                };

                var pictureBox = new PictureBox
                {
                    ImageLocation = exchange.ImageUrl,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(100, 100),
                    Location = new Point(10, 10)
                };

                var details = new Label
                {
                    Text = $"{exchange.Title}\n{exchange.Description}",
                    Location = new Point(120, 10),
                    Size = new Size(500, 60),  // Réduit la largeur pour laisser de la place aux boutons
                    Font = new Font("Arial", 10),
                    ForeColor = Color.Black
                };

                var status = new Label
                {
                    Text = exchange.Status,
                    Location = new Point(120, 70),
                    AutoSize = true,
                    Padding = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = GetStatusColor(exchange.Status),
                    ForeColor = Color.White,
                    Font = new Font("Arial", 10, FontStyle.Bold)
                };

                var date = new Label
                {
                    Text = exchange.Date.ToString("d MMM yyyy"),
                    Location = new Point(120, 100),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                // Création du panneau pour les actions
                var actions = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoSize = true,
                    Location = new Point(exchangeItem.Width - 220, exchangeItem.Height - 40),  // Positionné en bas à droite
                    Anchor = AnchorStyles.Bottom | AnchorStyles.Right,  // Assure que le panel reste en bas à droite
                    Padding = new Padding(5)
                };

                var btnView = new Button
                {
                    Text = "Voir les détails",
                    BackColor = Color.FromArgb(0, 160, 233),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                var btnCancel = new Button
                {
                    Text = "Annuler",
                    BackColor = Color.FromArgb(244, 67, 54),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Margin = new Padding(5)
                };

                // Ajout des boutons dans le `FlowLayoutPanel`
                actions.Controls.Add(btnView);
                actions.Controls.Add(btnCancel);

                // Ajout des contrôles dans `exchangeItem`
                exchangeItem.Controls.Add(pictureBox);
                exchangeItem.Controls.Add(details);
                exchangeItem.Controls.Add(status);
                exchangeItem.Controls.Add(date);
                exchangeItem.Controls.Add(actions);  // Ajout du panneau des actions

                // Finalement, ajout de `exchangeItem` dans `myExchangesPanel`
                this.myExchangesPanel.Controls.Add(exchangeItem);


            }

            //mainWindowPanel.Controls.Add(exchangeList);
        }
        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "En attente": return Color.FromArgb(255, 215, 0); // Yellow
                case "Accepté": return Color.FromArgb(76, 175, 80); // Green
                case "Refusé": return Color.FromArgb(244, 67, 54); // Red
                default: return Color.Gray; // Default color
            }
        }


        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel searchBarPanel;
        private System.Windows.Forms.Panel windowHeaderPanel;
        private System.Windows.Forms.Label windowTitleLabel;
        private System.Windows.Forms.Panel windowControlsPanel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button windowCloseButton;
        private System.Windows.Forms.Button windowMinimizeButton;
        private System.Windows.Forms.Button windowMaximizeButton;
        private System.Windows.Forms.Button productsButton;
        private System.Windows.Forms.Button productsListButton;
        private System.Windows.Forms.Panel windowContentPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel userActionsPanel;
        private System.Windows.Forms.LinkLabel loginLink;
        private System.Windows.Forms.LinkLabel signUpLink;
        private System.Windows.Forms.FlowLayoutPanel productGridPanel;
        private System.Windows.Forms.Form addProductModal;
        private System.Windows.Forms.Form proposeExchangeModal;
        private System.Windows.Forms.Panel panelProductDetails;
        private System.Windows.Forms.FlowLayoutPanel myExchangesPanel;
        private System.Windows.Forms.Panel mainWindowPanel;
        private System.Windows.Forms.Panel sideBarPanel;
        

    }
}
