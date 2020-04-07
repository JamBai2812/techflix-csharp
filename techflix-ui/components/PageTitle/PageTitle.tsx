﻿import React, {FunctionComponent} from "react";
import styles from "./PageTitle.module.scss"

export const PageTitle: FunctionComponent = ({children}) => {
    return (
        <h1 data-test-id="hero-title" className={styles.title}>{children}</h1>
    );
};