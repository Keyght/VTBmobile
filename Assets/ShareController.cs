using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShareController : MonoBehaviour {

	public void ShareIt (string app) {
		if (app != "ok")
			Sharing.ShareVia (app, "Инвестиции - это просто! Приглашаю учиться инвестициям вместе со мной \n (ссылка)");
		else
			Sharing.ShareVia (app, "Инвестиции - это просто! Приглашаю учиться инвестициям вместе со мной \n (ссылка)", string.Format("{0};{1}", App.OdnoklassnikiAppId, App.OdnoklassnikiSecretId));
	}
}
