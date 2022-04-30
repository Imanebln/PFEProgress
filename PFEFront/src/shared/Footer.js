const Footer = () => {
	const link = "https://henok.us";
	const target = "_blank";

	return (
		<div className="container">
			Copyright © <small>{new Date().getFullYear()}</small> PFEProgress{" "}
			<a href={link} target={target}>
				PFEProgress.ma
			</a>
		</div>
	);
};

export default Footer;
