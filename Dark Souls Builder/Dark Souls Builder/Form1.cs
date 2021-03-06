﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginBase;
using Dark_Souls_Builder.Class_Manager;


namespace Dark_Souls_Builder
{
    public partial class Form1 : Form
    {
        private Class_Manager.Class__Manager class_manager;
        private Plugin_Manager pm = new Plugin_Manager();
        public Form1()
        {
            InitializeComponent();
            class_manager = new Class__Manager();
            string[] buf = class_manager.GetClasses();
            ClassesCB.Items.Clear();
            for (int i = 0; i < buf.Length; i++)
            {
                ClassesCB.Items.Add(buf[i]);
            }
            buf = class_manager.GetSerialisers();
            SerializersCB.Items.Clear();
            for (int i = 0; i < buf.Length; i++)
            {
                SerializersCB.Items.Add(buf[i]);
            }
            ConfrimBT.Enabled = false;
            PropTB.Enabled = false;
            PropertiesCB.Enabled = false;
        }

        private void UpdateObjs()
        {
            ObjectsLB.Items.Clear();
            int buf = class_manager.GetEditObjNum();
            for (int i = 0; i < class_manager.GetObjNum(); i++)
            {
                class_manager.SetActiveObj(i);
                ObjectsLB.Items.Add(class_manager.GetName());
            }
            if (class_manager.GetObjNum() > 0)
            {
                class_manager.SetActiveObj(buf);
                ObjectsLB.SelectedIndex = class_manager.GetEditObjNum();
            }
        }

        private void UpdateProps()
        {
            InfoLB.Items.Clear();
            ConfrimBT.Enabled = false;
            if (ObjectsLB.SelectedIndex != -1)
            {
                string[] obj_info = class_manager.GetObjInfoTxt();
                for (int i = 0; i < obj_info.Length; i++)
                    InfoLB.Items.Add(obj_info[i]);
                InfoLB.SelectedIndex = class_manager.GetEditPropNum();
                ConfrimBT.Enabled = true;
                PropTB.Enabled = true;
                PropertiesCB.Enabled = true;
            }
        }

        private void CreateBT_Click(object sender, EventArgs e)
        {
            if (ClassesCB.Text == "")
                MessageBox.Show("Choose class pls!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                class_manager.CreateObject(ClassesCB.Text);
                class_manager.SetActiveLastObj();
                UpdateObjs();
                ObjectsLB.SelectedIndex = class_manager.GetEditObjNum();
            }
        }

        private void ObjectsLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            class_manager.SetActiveObj(ObjectsLB.SelectedIndex);
            UpdateProps();
            /*obj_info = class_manager.GetProperties();
            PropertiesCB.Items.Clear();
            for (int i = 0; i < obj_info.Length; i++)
                PropertiesCB.Items.Add(obj_info[i]);*/
        }

        private void InfoLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            class_manager.SetActiveProp(InfoLB.SelectedIndex);
            PropertiesCB.Visible = class_manager.IsPropClass();
            PropTB.Visible = !class_manager.IsPropClass();
            PropertiesCB.Items.Clear();
            PropTB.Clear();
            if (PropertiesCB.Enabled)
            {
                string[] buf = class_manager.GetChildObjectsTxt();
                for (int i = 0; i < buf.Length; i++)
                {
                    PropertiesCB.Items.Add(buf[i]);
                }
            }
        }

        private void ConfrimBT_Click(object sender, EventArgs e)
        {
            if (PropertiesCB.Visible)
                class_manager.SetPropVal(PropertiesCB.Text, PropertiesCB.SelectedIndex);
            else
            {
                if (!class_manager.SetPropVal(PropTB.Text, 0))
                {
                    MessageBox.Show("Wrong value!", "Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            UpdateObjs();
            UpdateProps();
        }

        private void RemoveBT_Click(object sender, EventArgs e)
        {
            if (ObjectsLB.SelectedIndex == -1)
                MessageBox.Show("No objects selected!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                class_manager.DeleteObj();
                UpdateObjs();
            }
        }

        private void LoadBT_Click(object sender, EventArgs e)
        {
            if (OpenFileD.ShowDialog() == DialogResult.Cancel)
                return;
            if (SerializersCB.Text == "")
            {
                MessageBox.Show("Choose serializer pls!", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            class_manager.Load(OpenFileD.FileName, SerializersCB.Text);
            UpdateObjs();
        }

        private void SaveBT_Click(object sender, EventArgs e)
        {
            if (SaveFileD.ShowDialog() == DialogResult.Cancel)
                return;
            if (SerializersCB.Text == "" || ObjectsLB.Items.Count == 0)
            {
                MessageBox.Show("Choose serializer and create at least one object pls!", "Message",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            class_manager.Save(SaveFileD.FileName, SerializersCB.Text);
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            pm.ScanPlugins(AppDomain.CurrentDomain.BaseDirectory + "\\Plugins\\");
            comboBox1.Items.Clear();
            foreach (var plugin in pm.Plugins)
                comboBox1.Items.Add(plugin.Name);
        }

        private void EncodeBT_Click(object sender, EventArgs e)
        {
            if (OpenFileD.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (var plugin in pm.Plugins)
                if (comboBox1.SelectedItem.ToString() == plugin.Name)
                    plugin.EncodeFile(OpenFileD.FileName);
        }

        private void DecodeBT_Click(object sender, EventArgs e)
        {
            if (OpenFileD.ShowDialog() == DialogResult.Cancel)
                return;
            foreach (var plugin in pm.Plugins)
                if (comboBox1.SelectedItem.ToString() == plugin.Name)
                    plugin.DecodeFile(OpenFileD.FileName);
        }
    }
}
