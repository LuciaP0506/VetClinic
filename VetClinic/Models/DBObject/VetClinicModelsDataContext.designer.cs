﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VetClinic.Models.DBObject
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="vetClinic")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertConsultation(Consultation instance);
    partial void UpdateConsultation(Consultation instance);
    partial void DeleteConsultation(Consultation instance);
    partial void InsertInvoice(Invoice instance);
    partial void UpdateInvoice(Invoice instance);
    partial void DeleteInvoice(Invoice instance);
    partial void InsertOwner(Owner instance);
    partial void UpdateOwner(Owner instance);
    partial void DeleteOwner(Owner instance);
    partial void InsertPet(Pet instance);
    partial void UpdatePet(Pet instance);
    partial void DeletePet(Pet instance);
    partial void InsertVet(Vet instance);
    partial void UpdateVet(Vet instance);
    partial void DeleteVet(Vet instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["vetClinicConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Consultation> Consultations
		{
			get
			{
				return this.GetTable<Consultation>();
			}
		}
		
		public System.Data.Linq.Table<Invoice> Invoices
		{
			get
			{
				return this.GetTable<Invoice>();
			}
		}
		
		public System.Data.Linq.Table<Owner> Owners
		{
			get
			{
				return this.GetTable<Owner>();
			}
		}
		
		public System.Data.Linq.Table<Pet> Pets
		{
			get
			{
				return this.GetTable<Pet>();
			}
		}
		
		public System.Data.Linq.Table<Vet> Vets
		{
			get
			{
				return this.GetTable<Vet>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Consultations")]
	public partial class Consultation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _IdConsultation;
		
		private System.Guid _IdVet;
		
		private System.Guid _IdPet;
		
		private string _Description;
		
		private string _Recomandation;
		
		private System.DateTime _EventDate;
		
		private System.Guid _IdOwner;
		
		private EntitySet<Invoice> _Invoices;
		
		private EntityRef<Owner> _Owner;
		
		private EntityRef<Pet> _Pet;
		
		private EntityRef<Vet> _Vet;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdConsultationChanging(System.Guid value);
    partial void OnIdConsultationChanged();
    partial void OnIdVetChanging(System.Guid value);
    partial void OnIdVetChanged();
    partial void OnIdPetChanging(System.Guid value);
    partial void OnIdPetChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnRecomandationChanging(string value);
    partial void OnRecomandationChanged();
    partial void OnEventDateChanging(System.DateTime value);
    partial void OnEventDateChanged();
    partial void OnIdOwnerChanging(System.Guid value);
    partial void OnIdOwnerChanged();
    #endregion
		
		public Consultation()
		{
			this._Invoices = new EntitySet<Invoice>(new Action<Invoice>(this.attach_Invoices), new Action<Invoice>(this.detach_Invoices));
			this._Owner = default(EntityRef<Owner>);
			this._Pet = default(EntityRef<Pet>);
			this._Vet = default(EntityRef<Vet>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdConsultation", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid IdConsultation
		{
			get
			{
				return this._IdConsultation;
			}
			set
			{
				if ((this._IdConsultation != value))
				{
					this.OnIdConsultationChanging(value);
					this.SendPropertyChanging();
					this._IdConsultation = value;
					this.SendPropertyChanged("IdConsultation");
					this.OnIdConsultationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdVet", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdVet
		{
			get
			{
				return this._IdVet;
			}
			set
			{
				if ((this._IdVet != value))
				{
					if (this._Vet.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdVetChanging(value);
					this.SendPropertyChanging();
					this._IdVet = value;
					this.SendPropertyChanged("IdVet");
					this.OnIdVetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdPet", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdPet
		{
			get
			{
				return this._IdPet;
			}
			set
			{
				if ((this._IdPet != value))
				{
					if (this._Pet.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdPetChanging(value);
					this.SendPropertyChanging();
					this._IdPet = value;
					this.SendPropertyChanged("IdPet");
					this.OnIdPetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Recomandation", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Recomandation
		{
			get
			{
				return this._Recomandation;
			}
			set
			{
				if ((this._Recomandation != value))
				{
					this.OnRecomandationChanging(value);
					this.SendPropertyChanging();
					this._Recomandation = value;
					this.SendPropertyChanged("Recomandation");
					this.OnRecomandationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventDate", DbType="DateTime NOT NULL")]
		public System.DateTime EventDate
		{
			get
			{
				return this._EventDate;
			}
			set
			{
				if ((this._EventDate != value))
				{
					this.OnEventDateChanging(value);
					this.SendPropertyChanging();
					this._EventDate = value;
					this.SendPropertyChanged("EventDate");
					this.OnEventDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOwner", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdOwner
		{
			get
			{
				return this._IdOwner;
			}
			set
			{
				if ((this._IdOwner != value))
				{
					if (this._Owner.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdOwnerChanging(value);
					this.SendPropertyChanging();
					this._IdOwner = value;
					this.SendPropertyChanged("IdOwner");
					this.OnIdOwnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Consultation_Invoice", Storage="_Invoices", ThisKey="IdConsultation", OtherKey="IdConsultation")]
		public EntitySet<Invoice> Invoices
		{
			get
			{
				return this._Invoices;
			}
			set
			{
				this._Invoices.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Owner_Consultation", Storage="_Owner", ThisKey="IdOwner", OtherKey="IdOwner", IsForeignKey=true)]
		public Owner Owner
		{
			get
			{
				return this._Owner.Entity;
			}
			set
			{
				Owner previousValue = this._Owner.Entity;
				if (((previousValue != value) 
							|| (this._Owner.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Owner.Entity = null;
						previousValue.Consultations.Remove(this);
					}
					this._Owner.Entity = value;
					if ((value != null))
					{
						value.Consultations.Add(this);
						this._IdOwner = value.IdOwner;
					}
					else
					{
						this._IdOwner = default(System.Guid);
					}
					this.SendPropertyChanged("Owner");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pet_Consultation", Storage="_Pet", ThisKey="IdPet", OtherKey="IdPet", IsForeignKey=true)]
		public Pet Pet
		{
			get
			{
				return this._Pet.Entity;
			}
			set
			{
				Pet previousValue = this._Pet.Entity;
				if (((previousValue != value) 
							|| (this._Pet.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pet.Entity = null;
						previousValue.Consultations.Remove(this);
					}
					this._Pet.Entity = value;
					if ((value != null))
					{
						value.Consultations.Add(this);
						this._IdPet = value.IdPet;
					}
					else
					{
						this._IdPet = default(System.Guid);
					}
					this.SendPropertyChanged("Pet");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vet_Consultation", Storage="_Vet", ThisKey="IdVet", OtherKey="IdVet", IsForeignKey=true)]
		public Vet Vet
		{
			get
			{
				return this._Vet.Entity;
			}
			set
			{
				Vet previousValue = this._Vet.Entity;
				if (((previousValue != value) 
							|| (this._Vet.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Vet.Entity = null;
						previousValue.Consultations.Remove(this);
					}
					this._Vet.Entity = value;
					if ((value != null))
					{
						value.Consultations.Add(this);
						this._IdVet = value.IdVet;
					}
					else
					{
						this._IdVet = default(System.Guid);
					}
					this.SendPropertyChanged("Vet");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Invoices(Invoice entity)
		{
			this.SendPropertyChanging();
			entity.Consultation = this;
		}
		
		private void detach_Invoices(Invoice entity)
		{
			this.SendPropertyChanging();
			entity.Consultation = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Invoices")]
	public partial class Invoice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _IdInvoice;
		
		private System.Guid _IdConsultation;
		
		private System.Guid _IdOwner;
		
		private decimal _Price;
		
		private System.DateTime _EventDate;
		
		private EntityRef<Consultation> _Consultation;
		
		private EntityRef<Owner> _Owner;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdInvoiceChanging(System.Guid value);
    partial void OnIdInvoiceChanged();
    partial void OnIdConsultationChanging(System.Guid value);
    partial void OnIdConsultationChanged();
    partial void OnIdOwnerChanging(System.Guid value);
    partial void OnIdOwnerChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    partial void OnEventDateChanging(System.DateTime value);
    partial void OnEventDateChanged();
    #endregion
		
		public Invoice()
		{
			this._Consultation = default(EntityRef<Consultation>);
			this._Owner = default(EntityRef<Owner>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdInvoice", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid IdInvoice
		{
			get
			{
				return this._IdInvoice;
			}
			set
			{
				if ((this._IdInvoice != value))
				{
					this.OnIdInvoiceChanging(value);
					this.SendPropertyChanging();
					this._IdInvoice = value;
					this.SendPropertyChanged("IdInvoice");
					this.OnIdInvoiceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdConsultation", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdConsultation
		{
			get
			{
				return this._IdConsultation;
			}
			set
			{
				if ((this._IdConsultation != value))
				{
					if (this._Consultation.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdConsultationChanging(value);
					this.SendPropertyChanging();
					this._IdConsultation = value;
					this.SendPropertyChanged("IdConsultation");
					this.OnIdConsultationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOwner", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdOwner
		{
			get
			{
				return this._IdOwner;
			}
			set
			{
				if ((this._IdOwner != value))
				{
					if (this._Owner.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdOwnerChanging(value);
					this.SendPropertyChanging();
					this._IdOwner = value;
					this.SendPropertyChanged("IdOwner");
					this.OnIdOwnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(18,0) NOT NULL")]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventDate", DbType="DateTime NOT NULL")]
		public System.DateTime EventDate
		{
			get
			{
				return this._EventDate;
			}
			set
			{
				if ((this._EventDate != value))
				{
					this.OnEventDateChanging(value);
					this.SendPropertyChanging();
					this._EventDate = value;
					this.SendPropertyChanged("EventDate");
					this.OnEventDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Consultation_Invoice", Storage="_Consultation", ThisKey="IdConsultation", OtherKey="IdConsultation", IsForeignKey=true)]
		public Consultation Consultation
		{
			get
			{
				return this._Consultation.Entity;
			}
			set
			{
				Consultation previousValue = this._Consultation.Entity;
				if (((previousValue != value) 
							|| (this._Consultation.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Consultation.Entity = null;
						previousValue.Invoices.Remove(this);
					}
					this._Consultation.Entity = value;
					if ((value != null))
					{
						value.Invoices.Add(this);
						this._IdConsultation = value.IdConsultation;
					}
					else
					{
						this._IdConsultation = default(System.Guid);
					}
					this.SendPropertyChanged("Consultation");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Owner_Invoice", Storage="_Owner", ThisKey="IdOwner", OtherKey="IdOwner", IsForeignKey=true)]
		public Owner Owner
		{
			get
			{
				return this._Owner.Entity;
			}
			set
			{
				Owner previousValue = this._Owner.Entity;
				if (((previousValue != value) 
							|| (this._Owner.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Owner.Entity = null;
						previousValue.Invoices.Remove(this);
					}
					this._Owner.Entity = value;
					if ((value != null))
					{
						value.Invoices.Add(this);
						this._IdOwner = value.IdOwner;
					}
					else
					{
						this._IdOwner = default(System.Guid);
					}
					this.SendPropertyChanged("Owner");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Owners")]
	public partial class Owner : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _IdOwner;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Phone;
		
		private string _Email;
		
		private string _Address;
		
		private EntitySet<Consultation> _Consultations;
		
		private EntitySet<Invoice> _Invoices;
		
		private EntitySet<Pet> _Pets;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdOwnerChanging(System.Guid value);
    partial void OnIdOwnerChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    #endregion
		
		public Owner()
		{
			this._Consultations = new EntitySet<Consultation>(new Action<Consultation>(this.attach_Consultations), new Action<Consultation>(this.detach_Consultations));
			this._Invoices = new EntitySet<Invoice>(new Action<Invoice>(this.attach_Invoices), new Action<Invoice>(this.detach_Invoices));
			this._Pets = new EntitySet<Pet>(new Action<Pet>(this.attach_Pets), new Action<Pet>(this.detach_Pets));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOwner", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid IdOwner
		{
			get
			{
				return this._IdOwner;
			}
			set
			{
				if ((this._IdOwner != value))
				{
					this.OnIdOwnerChanging(value);
					this.SendPropertyChanging();
					this._IdOwner = value;
					this.SendPropertyChanged("IdOwner");
					this.OnIdOwnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(250)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Owner_Consultation", Storage="_Consultations", ThisKey="IdOwner", OtherKey="IdOwner")]
		public EntitySet<Consultation> Consultations
		{
			get
			{
				return this._Consultations;
			}
			set
			{
				this._Consultations.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Owner_Invoice", Storage="_Invoices", ThisKey="IdOwner", OtherKey="IdOwner")]
		public EntitySet<Invoice> Invoices
		{
			get
			{
				return this._Invoices;
			}
			set
			{
				this._Invoices.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Owner_Pet", Storage="_Pets", ThisKey="IdOwner", OtherKey="IdOwner")]
		public EntitySet<Pet> Pets
		{
			get
			{
				return this._Pets;
			}
			set
			{
				this._Pets.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Consultations(Consultation entity)
		{
			this.SendPropertyChanging();
			entity.Owner = this;
		}
		
		private void detach_Consultations(Consultation entity)
		{
			this.SendPropertyChanging();
			entity.Owner = null;
		}
		
		private void attach_Invoices(Invoice entity)
		{
			this.SendPropertyChanging();
			entity.Owner = this;
		}
		
		private void detach_Invoices(Invoice entity)
		{
			this.SendPropertyChanging();
			entity.Owner = null;
		}
		
		private void attach_Pets(Pet entity)
		{
			this.SendPropertyChanging();
			entity.Owner = this;
		}
		
		private void detach_Pets(Pet entity)
		{
			this.SendPropertyChanging();
			entity.Owner = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pets")]
	public partial class Pet : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _IdPet;
		
		private string _Name;
		
		private string _Species;
		
		private string _Race;
		
		private System.Guid _IdOwner;
		
		private EntitySet<Consultation> _Consultations;
		
		private EntityRef<Owner> _Owner;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdPetChanging(System.Guid value);
    partial void OnIdPetChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnSpeciesChanging(string value);
    partial void OnSpeciesChanged();
    partial void OnRaceChanging(string value);
    partial void OnRaceChanged();
    partial void OnIdOwnerChanging(System.Guid value);
    partial void OnIdOwnerChanged();
    #endregion
		
		public Pet()
		{
			this._Consultations = new EntitySet<Consultation>(new Action<Consultation>(this.attach_Consultations), new Action<Consultation>(this.detach_Consultations));
			this._Owner = default(EntityRef<Owner>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdPet", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid IdPet
		{
			get
			{
				return this._IdPet;
			}
			set
			{
				if ((this._IdPet != value))
				{
					this.OnIdPetChanging(value);
					this.SendPropertyChanging();
					this._IdPet = value;
					this.SendPropertyChanged("IdPet");
					this.OnIdPetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Species", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Species
		{
			get
			{
				return this._Species;
			}
			set
			{
				if ((this._Species != value))
				{
					this.OnSpeciesChanging(value);
					this.SendPropertyChanging();
					this._Species = value;
					this.SendPropertyChanged("Species");
					this.OnSpeciesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Race", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Race
		{
			get
			{
				return this._Race;
			}
			set
			{
				if ((this._Race != value))
				{
					this.OnRaceChanging(value);
					this.SendPropertyChanging();
					this._Race = value;
					this.SendPropertyChanged("Race");
					this.OnRaceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdOwner", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IdOwner
		{
			get
			{
				return this._IdOwner;
			}
			set
			{
				if ((this._IdOwner != value))
				{
					if (this._Owner.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdOwnerChanging(value);
					this.SendPropertyChanging();
					this._IdOwner = value;
					this.SendPropertyChanged("IdOwner");
					this.OnIdOwnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pet_Consultation", Storage="_Consultations", ThisKey="IdPet", OtherKey="IdPet")]
		public EntitySet<Consultation> Consultations
		{
			get
			{
				return this._Consultations;
			}
			set
			{
				this._Consultations.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Owner_Pet", Storage="_Owner", ThisKey="IdOwner", OtherKey="IdOwner", IsForeignKey=true)]
		public Owner Owner
		{
			get
			{
				return this._Owner.Entity;
			}
			set
			{
				Owner previousValue = this._Owner.Entity;
				if (((previousValue != value) 
							|| (this._Owner.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Owner.Entity = null;
						previousValue.Pets.Remove(this);
					}
					this._Owner.Entity = value;
					if ((value != null))
					{
						value.Pets.Add(this);
						this._IdOwner = value.IdOwner;
					}
					else
					{
						this._IdOwner = default(System.Guid);
					}
					this.SendPropertyChanged("Owner");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Consultations(Consultation entity)
		{
			this.SendPropertyChanging();
			entity.Pet = this;
		}
		
		private void detach_Consultations(Consultation entity)
		{
			this.SendPropertyChanging();
			entity.Pet = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Vets")]
	public partial class Vet : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _IdVet;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Specialization;
		
		private string _Phone;
		
		private string _Email;
		
		private EntitySet<Consultation> _Consultations;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdVetChanging(System.Guid value);
    partial void OnIdVetChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnSpecializationChanging(string value);
    partial void OnSpecializationChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public Vet()
		{
			this._Consultations = new EntitySet<Consultation>(new Action<Consultation>(this.attach_Consultations), new Action<Consultation>(this.detach_Consultations));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdVet", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid IdVet
		{
			get
			{
				return this._IdVet;
			}
			set
			{
				if ((this._IdVet != value))
				{
					this.OnIdVetChanging(value);
					this.SendPropertyChanging();
					this._IdVet = value;
					this.SendPropertyChanged("IdVet");
					this.OnIdVetChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Specialization", DbType="VarChar(250) NOT NULL", CanBeNull=false)]
		public string Specialization
		{
			get
			{
				return this._Specialization;
			}
			set
			{
				if ((this._Specialization != value))
				{
					this.OnSpecializationChanging(value);
					this.SendPropertyChanging();
					this._Specialization = value;
					this.SendPropertyChanged("Specialization");
					this.OnSpecializationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="VarChar(50)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="VarChar(250)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Vet_Consultation", Storage="_Consultations", ThisKey="IdVet", OtherKey="IdVet")]
		public EntitySet<Consultation> Consultations
		{
			get
			{
				return this._Consultations;
			}
			set
			{
				this._Consultations.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Consultations(Consultation entity)
		{
			this.SendPropertyChanging();
			entity.Vet = this;
		}
		
		private void detach_Consultations(Consultation entity)
		{
			this.SendPropertyChanging();
			entity.Vet = null;
		}
	}
}
#pragma warning restore 1591
